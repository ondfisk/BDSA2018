using BDSA2018.Lecture05.Entities;
using BDSA2018.Lecture05.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace BDSA2018.Lecture05.Tests
{
    public class CharacterRepositoryTests
    {
        public IFuturamaContext CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<FuturamaContext>()
                              .UseSqlite(connection);

            var context = new FuturamaContext(builder.Options);
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public void Find_given_id_exists_returns_dto()
        {
            var builder = new DbContextOptionsBuilder<FuturamaContext>()
                    .UseInMemoryDatabase(databaseName: nameof(Find_given_id_exists_returns_dto));
            var context = new FuturamaContext(builder.Options);

            var entity = new Character
            {
                Name = "Fry",
                Species = "Human",
                Planet = "Earth",
                Actor = new Actor { Name = "Billy West" }
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
        }

        [Fact]
        public void Find_given_id_exists_returns_dto_with_episodeCount()
        {
            var builder = new DbContextOptionsBuilder<FuturamaContext>()
                    .UseInMemoryDatabase(databaseName: nameof(Find_given_id_exists_returns_dto_with_episodeCount));
            var context = new FuturamaContext(builder.Options);

            var episode1 = new Episode { Title = "Space Pilot 3000" };
            var episode2 = new Episode { Title = "The Series Has Landed" };
            context.Episodes.AddRange(episode1, episode2);

            var entity = new Character
            {
                EpisodeCharacters = new[] 
                {
                    new EpisodeCharacter { Episode = episode1 },
                    new EpisodeCharacter { Episode = episode2 }
                }
            };
            context.Characters.Add(entity);
            context.SaveChanges();

            var repository = new CharacterRepository(context);

            var character = repository.Find(1);

            Assert.Equal(2, character.NumberOfEpisodes);
        }

        [Fact]
        public void Read_returns_projection_of_all_characters()
        {
            var context = CreateInMemoryDatabase();

            var episode1 = new Episode { Title = "Space Pilot 3000" };
            var episode2 = new Episode { Title = "The Series Has Landed" };
            context.Episodes.AddRange(episode1, episode2);

            var entity = new Character
            {
                Name = "Fry",
                Species = "Human",
                EpisodeCharacters = new[]
                {
                    new EpisodeCharacter { Episode = episode1 },
                    new EpisodeCharacter { Episode = episode2 }
                }
            };
            context.Characters.Add(entity);
            context.SaveChanges();

            var repository = new CharacterRepository(context);

            var characters = repository.Read();

            var character = characters.First();

            Assert.Equal(2, character.NumberOfEpisodes);
        }

        [Fact]
        public void Read_returns_projection_of_runtime_type_ReadOnly()
        {
            var context = CreateInMemoryDatabase();

            var entity = new Character
            {
                Name = "Fry",
                Species = "Human"
            };
            context.Characters.Add(entity);
            context.SaveChanges();

            var repository = new CharacterRepository(context);

            var characters = repository.Read();

            Assert.IsType<ReadOnlyCollection<CharacterDTO>>(characters);
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
    }
}
