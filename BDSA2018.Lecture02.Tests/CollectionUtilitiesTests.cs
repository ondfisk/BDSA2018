using System.Collections.Generic;
using Xunit;

namespace BDSA2018.Lecture02.Tests
{
    public class CollectionUtilitiesTests
    {
        [Fact]
        public void GetEven_given_1_2_3_4_5_returns_2_4()
        {
            var input = new[] { 1, 2, 3, 4, 5 };

            var even = CollectionUtilities.GetEven(input);

            Assert.Equal(new[] { 2, 4 }, even);
        }

        [Fact]
        public void Unique_given_1_2_2_2_3_returns_1_2_3()
        {
            var input = new[] { 1, 2, 2, 2, 3 };

            var even = CollectionUtilities.Unique(input);

            // Not possible with Xunit - can be done with MSTest or NUnit using CollectionAssert
            //Assert.Equal(new HashSet<int> { 3, 2, 1 }, even);

            Assert.True(even.SetEquals(new[] { 3, 2, 1 }));
        }

        [Fact]
        public void Reverse()
        {
            var input = new[] { 1, 2, 3 };

            var even = CollectionUtilities.Reverse(input);

            Assert.Equal(new[] { 3, 2, 1 }, even);
        }
    }
}
