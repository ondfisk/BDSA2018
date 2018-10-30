using System;
using System.Collections.Generic;
using Xunit;

namespace Futurama.Entities.Tests
{
    public class CharacterTests
    {
        [Fact]
        public void EpisodeCharacters_is_HashSet_of_EpisodeCharacter()
        {
            var character = new Character();

            Assert.IsType<HashSet<EpisodeCharacter>>(character.EpisodeCharacters);
        }
    }
}
