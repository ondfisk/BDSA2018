using System;
using Xunit;

namespace BDSA2018.Lecture02.Tests
{
    public class PostalCodeValidatorTests
    {
        [Theory]
        [InlineData("foo", false)]
        [InlineData("2000", true)]
        [InlineData("8000", true)]
        [InlineData("5000", true)]
        public void IsValid_given_postalCode_returns_expected(string postalCode, bool expected)
        {
            var valid = PostalCodeValidator.IsValid(postalCode);

            Assert.Equal(expected, valid);
        }

        [Fact]
        public void TryParse_given_2000_Frederiksberg_C_returns_true()
        {
            var parsed = PostalCodeValidator.TryParse("2000 Frederiksberg C", out var postalCode, out var locality);

            Assert.True(parsed);
            Assert.Equal("2000", postalCode);
            Assert.Equal("Frederiksberg C", locality);
        }
    }
}
