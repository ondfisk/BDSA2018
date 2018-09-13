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

        [Theory]
        [InlineData("2000 Frederiksberg C")]
        [InlineData("100 Tórshavn")]
        public void TryParse_given_postalCodeAndLocality_returns_true(string postalCodeAndLocality)
        {
            var parsed = PostalCodeValidator.TryParse(postalCodeAndLocality, out var _, out var _);

            Assert.True(parsed);
        }

        [Theory]
        [InlineData("2000 Frederiksberg C", "2000", "Frederiksberg C")]
        [InlineData("100 Tórshavn", "100", "Tórshavn")]
        public void TryParse_given_postalCodeAndLocality_maps_postalCode_and_locality(string postalCodeAndLocality, string expectedPostalCode, string expectedLocality)
        {
            var parsed = PostalCodeValidator.TryParse(postalCodeAndLocality, out var postalCode, out var locality);

            Assert.Equal(expectedPostalCode, postalCode);
            Assert.Equal(expectedLocality, locality);
        }
    }
}
