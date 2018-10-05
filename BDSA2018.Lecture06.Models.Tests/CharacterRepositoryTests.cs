using BDSA2018.Lecture06.Entities;
using BDSA2018.Lecture06.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using Xunit;

namespace BDSA2018.Lecture06.Tests
{
    public class CharacterRepositoryTests
    {
        [Fact]
        public void Create_given_dto_creates_new_Character()
        {
            using (var connection = CreateConnection())
            using (var context = CreateContext(connection))
            {
                context.Actors.Add(new Actor { Name = "John DiMaggio" });
                context.SaveChanges();

                var repository = new CharacterRepository(context);
                var dto = new CharacterCreateUpdateDTO
                {
                    ActorId = 1,
                    Name = "Bender",
                    Species = "Robot",
                    Planet = "Earth"
                };

                var id = repository.Create(dto);

                Assert.Equal(1, id);

                var entity = context.Characters.Find(1);

                Assert.Equal(1, entity.ActorId);
                Assert.Equal("Bender", entity.Name);
                Assert.Equal("Robot", entity.Species);
                Assert.Equal("Earth", entity.Planet);
            }
        }

        [Fact]
        public void Find_given_id_exists_returns_dto()
        {
            using (var connection = CreateConnection())
            using (var context = CreateContext(connection))
            {
                var entity = new Character
                {
                    Name = "Fry",
                    Species = "Human",
                    Planet = "Earth",
                    Actor = new Actor { Name = "Billy West" },
                    EpisodeCharacters = new[]
                    {
                        new EpisodeCharacter { Episode = new Episode { Title = "Space Pilot 3000" } },
                        new EpisodeCharacter { Episode = new Episode { Title = "The Series Has Landed" } }
                    }
                };
                context.Characters.Add(entity);
                context.SaveChanges();

                var repository = new CharacterRepository(context);

                var character = repository.Find(1);

                Assert.Equal(1, character.Id);
                Assert.Equal("Fry", character.Name);
                Assert.Equal("Human", character.Species);
                Assert.Equal("Earth", character.Planet);
                Assert.Equal(1, character.ActorId);
                Assert.Equal("Billy West", character.ActorName);
                Assert.Equal(2, character.NumberOfEpisodes);
            }
        }

        [Fact]
        public void Read_returns_projection_of_all_characters()
        {
            using (var connection = CreateConnection())
            using (var context = CreateContext(connection))
            {
                var episode1 = new Episode { Title = "Space Pilot 3000" };
                var episode2 = new Episode { Title = "The Series Has Landed" };
                context.Episodes.AddRange(episode1, episode2);

                var entity = new Character
                {
                    Name = "Fry",
                    Species = "Human",
                    Planet = "Earth",
                    Actor = new Actor { Name = "Billy West" },
                    EpisodeCharacters = new[]
                    {
                        new EpisodeCharacter { Episode = new Episode { Title = "Space Pilot 3000" } },
                        new EpisodeCharacter { Episode = new Episode { Title = "The Series Has Landed" } }
                    }
                };
                context.Characters.Add(entity);
                context.SaveChanges();

                var repository = new CharacterRepository(context);

                var characters = repository.Read();

                var character = characters.First();

                Assert.Equal(1, character.Id);
                Assert.Equal("Fry", character.Name);
                Assert.Equal("Human", character.Species);
                Assert.Equal("Earth", character.Planet);
                Assert.Equal(1, character.ActorId);
                Assert.Equal("Billy West", character.ActorName);
                Assert.Equal(2, character.NumberOfEpisodes);
            }
        }

        [Fact]
        public void Update_given_non_existing_dto_returns_false()
        {
            using (var connection = CreateConnection())
            using (var context = CreateContext(connection))
            {
                context.Actors.Add(new Actor { Name = "John DiMaggio" });
                context.SaveChanges();

                var repository = new CharacterRepository(context);
                var dto = new CharacterCreateUpdateDTO
                {
                    Id = 1,
                    ActorId = 1,
                    Name = "Bender",
                    Species = "Robot",
                    Planet = "Earth"
                };

                var updated = repository.Update(dto);

                Assert.False(updated);
            }
        }

        [Fact]
        public void Update_given_existing_dto_updates_entity()
        {
            using (var connection = CreateConnection())
            using (var context = CreateContext(connection))
            {
                context.Actors.Add(new Actor { Name = "John DiMaggio" });
                context.SaveChanges();

                context.Characters.Add(new Character { Name = "Fry", Species = "Human" });
                context.SaveChanges();

                var repository = new CharacterRepository(context);
                var dto = new CharacterCreateUpdateDTO
                {
                    Id = 1,
                    ActorId = 1,
                    Name = "Bender",
                    Species = "Robot",
                    Planet = "Earth"
                };

                var updated = repository.Update(dto);

                Assert.True(updated);

                var entity = context.Characters.Find(1);

                Assert.Equal(1, entity.ActorId);
                Assert.Equal("Bender", entity.Name);
                Assert.Equal("Robot", entity.Species);
                Assert.Equal("Earth", entity.Planet);
            }
        }

        [Fact]
        public void Delete_given_id_not_exists_return_false()
        {
            var mock = new Mock<IFuturamaContext>();
            mock.Setup(s => s.Characters.Find(42)).Returns(default(Character));

            var repository = new CharacterRepository(mock.Object);

            var deleted = repository.Delete(42);

            Assert.False(deleted);
        }

        [Fact]
        public void Delete_given_id_exists_character_is_removed_from_context()
        {
            var entity = new Character();
            var mock = new Mock<IFuturamaContext>();
            mock.Setup(s => s.Characters.Find(42)).Returns(entity);

            var repository = new CharacterRepository(mock.Object);

            repository.Delete(42);

            mock.Verify(s => s.Characters.Remove(entity));
        }

        [Fact]
        public void Delete_given_id_exists_context_SaveChanges()
        {
            var entity = new Character();
            var mock = new Mock<IFuturamaContext>();
            mock.Setup(s => s.Characters.Find(42)).Returns(entity);

            var repository = new CharacterRepository(mock.Object);

            repository.Delete(42);

            mock.Verify(s => s.SaveChanges());
        }

        [Fact]
        public void Delete_given_id_exists_return_true()
        {
            var entity = new Character();
            var mock = new Mock<IFuturamaContext>();
            mock.Setup(s => s.Characters.Find(42)).Returns(entity);

            var repository = new CharacterRepository(mock.Object);

            var deleted = repository.Delete(42);

            Assert.True(deleted);
        }

        private DbConnection CreateConnection()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            return connection;
        }

        private IFuturamaContext CreateContext(DbConnection connection)
        {
            var builder = new DbContextOptionsBuilder<FuturamaContext>()
                  .UseSqlite(connection);

            var context = new FuturamaContext(builder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
