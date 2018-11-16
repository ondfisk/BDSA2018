using BDSA2018.Lecture11.Entities;
using BDSA2018.Lecture11.Services;
using BDSA2018.Lecture11.Shared;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BDSA2018.Lecture11.Models.Tests
{
    public class EpisodeRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_given_dto_creates_new_Episode()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var bender = new Character { Name = "Bender", Species = "Robot" };
                var fry = new Character { Name = "Fry", Species = "Human" };
                context.Characters.AddRange(bender, fry);
                await context.SaveChangesAsync();

                var repository = new EpisodeRepository(context);
                var dto = new EpisodeCreateUpdateDTO
                {
                    Title = "Murder on the Planet Express",
                    FirstAired = new DateTime(2013, 8, 21),
                    CharacterIds = new[] { bender.Id, fry.Id }
                };

                var episode = await repository.CreateAsync(dto);

                Assert.Equal(1, episode.Id);

                var entity = await context.Episodes.FindAsync(episode.Id);

                Assert.Equal("Murder on the Planet Express", entity.Title);
                Assert.Equal(new DateTime(2013, 8, 21), entity.FirstAired);

                var characterIds = await context.EpisodeCharacters.Where(e => e.EpisodeId == episode.Id).Select(c => c.CharacterId).ToListAsync();

                Assert.True(new HashSet<int> { bender.Id, fry.Id }.SetEquals(characterIds));
            }
        }

        [Fact]
        public async Task CreateAsync_given_dto_returns_created_Episode()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var bender = new Character { Name = "Bender", Species = "Robot" };
                var fry = new Character { Name = "Fry", Species = "Human" };
                context.Characters.AddRange(bender, fry);
                await context.SaveChangesAsync();

                var repository = new EpisodeRepository(context);
                var dto = new EpisodeCreateUpdateDTO
                {
                    Title = "Murder on the Planet Express",
                    FirstAired = new DateTime(2013, 8, 21),
                    CharacterIds = new[] { bender.Id, fry.Id }
                };

                var episode = await repository.CreateAsync(dto);

                Assert.Equal(1, episode.Id);
                Assert.Equal("Murder on the Planet Express", episode.Title);
                Assert.Equal(new DateTime(2013, 8, 21), episode.FirstAired);
                Assert.Equal(new Dictionary<int, string> { { bender.Id, "Bender" }, { fry.Id, "Fry" } }, episode.Characters);
            }
        }

        [Fact]
        public async Task FindAsync_given_id_exists_returns_dto()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var bender = new Character { Name = "Bender", Species = "Robot" };
                var fry = new Character { Name = "Fry", Species = "Human" };
                var entity = new Episode
                {
                    Title = "Murder on the Planet Express",
                    FirstAired = new DateTime(2013, 8, 21),
                    EpisodeCharacters = new[]
                    {
                        new EpisodeCharacter { Character = bender },
                        new EpisodeCharacter { Character = fry }
                    }
                };
                context.Episodes.Add(entity);
                await context.SaveChangesAsync();

                var repository = new EpisodeRepository(context);

                var episode = await repository.FindAsync(entity.Id);

                Assert.Equal(1, episode.Id);
                Assert.Equal("Murder on the Planet Express", episode.Title);
                Assert.Equal(new DateTime(2013, 8, 21), episode.FirstAired);
                Assert.Equal(new Dictionary<int, string> { { bender.Id, "Bender" }, { fry.Id, "Fry" } }, episode.Characters);
            }
        }

        [Fact]
        public async Task Read_returns_projection_of_all_episodes()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var episode1 = new Episode { Title = "Space Pilot 3000", FirstAired = new DateTime(1999, 3, 28) };
                var episode2 = new Episode { Title = "The Series Has Landed", FirstAired = new DateTime(1999, 4, 4) };
                context.Episodes.AddRange(episode1, episode2);

                await context.SaveChangesAsync();

                var repository = new EpisodeRepository(context);

                var episodes = repository.Read().ToList();

                Assert.Collection(episodes, 
                    e => { Assert.Equal("Space Pilot 3000", e.Title); Assert.Equal(new DateTime(1999, 3, 28), e.FirstAired); },
                    e => { Assert.Equal("The Series Has Landed", e.Title); Assert.Equal(new DateTime(1999, 4, 4), e.FirstAired); }
                );
            }
        }

        [Fact]
        public async Task UpdateAsync_given_non_existing_dto_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new EpisodeRepository(context);
                var dto = new EpisodeCreateUpdateDTO
                {
                    Id = 0,
                    Title = "Dummy"
                };

                var updated = await repository.UpdateAsync(dto);

                Assert.False(updated);
            }
        }

        [Fact]
        public async Task UpdateAsync_given_existing_dto_updates_entity()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var bender = new Character { Name = "Bender", Species = "Robot" };
                var fry = new Character { Name = "Fry", Species = "Human" };
                var entity = new Episode
                {
                    Title = "Murder on the Planet Express",
                    FirstAired = new DateTime(2013, 8, 21),
                    EpisodeCharacters = new HashSet<EpisodeCharacter>
                    {
                        new EpisodeCharacter { Character = bender },
                        new EpisodeCharacter { Character = fry }
                    }
                };
                context.Episodes.Add(entity);
                await context.SaveChangesAsync();

                var repository = new EpisodeRepository(context);
                var dto = new EpisodeCreateUpdateDTO
                {
                    Id = entity.Id,
                    Title = "The Series Has Landed",
                    FirstAired = new DateTime(1999, 4, 4),
                    CharacterIds = new HashSet<int> { bender.Id }
                };

                var updated = await repository.UpdateAsync(dto);

                Assert.True(updated);

                var updatedEntity = await context.Episodes.Include(c => c.EpisodeCharacters).FirstOrDefaultAsync(c => c.Id == entity.Id);

                Assert.Equal("The Series Has Landed", updatedEntity.Title);
                Assert.Equal(new DateTime(1999, 4, 4), updatedEntity.FirstAired);
                Assert.Equal(bender.Id, updatedEntity.EpisodeCharacters.Single().CharacterId);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_existing_episodeId_returns_true()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Episode { Title = "The Series Has Landed" };
                context.Episodes.Add(entity);
                await context.SaveChangesAsync();

                var id = entity.Id;

                var repository = new EpisodeRepository(context);

                var deleted = await repository.DeleteAsync(id);

                Assert.True(deleted);
            }
        }

        [Fact]
        public async Task DeleteAsync_given_existing_episodeId_deletes_cascading()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var entity = new Episode { Title = "The Series Has Landed", EpisodeCharacters = new[] { new EpisodeCharacter { Character = new Character { Name = "Bender", Species = "Robot" } } } };
                context.Episodes.Add(entity);
                await context.SaveChangesAsync();

                var id = entity.Id;

                var repository = new EpisodeRepository(context);

                await repository.DeleteAsync(id);

                Assert.Null(await context.Episodes.FindAsync(id));
                Assert.Empty(await context.EpisodeCharacters.ToListAsync());
                Assert.NotNull(await context.Characters.FirstOrDefaultAsync(c => c.Name == "Bender"));
            }
        }

        [Fact]
        public async Task DeleteAsync_given_non_existing_episodeId_returns_false()
        {
            using (var connection = await CreateConnectionAsync())
            using (var context = await CreateContextAsync(connection))
            {
                var repository = new EpisodeRepository(context);

                var deleted = await repository.DeleteAsync(0);

                Assert.False(deleted);
            }
        }

        private async Task<DbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            await connection.OpenAsync();

            return connection;
        }

        private async Task<IFuturamaContext> CreateContextAsync(DbConnection connection)
        {
            var builder = new DbContextOptionsBuilder<FuturamaContext>()
                              .UseSqlite(connection);

            var context = new FuturamaTestContext(builder.Options);
            await context.Database.EnsureCreatedAsync();

            return context;
        }
    }
}
