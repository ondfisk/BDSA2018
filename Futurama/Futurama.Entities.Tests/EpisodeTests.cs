using System;
using System.Collections.Generic;
using Xunit;

namespace Futurama.Entities.Tests
{
    public class EpisodeTests
    {
        [Fact]
        public void EpisodeCharacters_is_HashSet_of_EpisodeCharacter()
        {
            var episode = new Episode();

            Assert.IsType<HashSet<EpisodeCharacter>>(episode.EpisodeCharacters);
        }
    }
}
