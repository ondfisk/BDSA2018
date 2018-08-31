using System;
using Xunit;

namespace BDSA2018.Lecture01.Lib.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_given_40_and_2_returns_42()
        {
            var calc = new Calculator();

            var res = calc.Add(40, 2);

            Assert.Equal(42, res);
        }
    }
}
