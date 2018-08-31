using System;
using System.IO;
using Xunit;

namespace BDSA2018.Lecture01.App.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_when_run_prints_HelloWorld()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Program.Main(new string[0]);

            var output = writer.GetStringBuilder().ToString().Trim();

            // Assert
            Assert.Equal("Hello World!", output);
        }

        [Fact]
        public void Main_given_null_prints_HelloWorld()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Program.Main(null);

            var output = writer.GetStringBuilder().ToString().Trim();

            // Assert
            Assert.Equal("Hello World!", output);
        }

        [Fact]
        public void Main_given_Superman_when_run_prints_Hello_Superman()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            string[] args = { "Superman" };

            // Act
            Program.Main(args);

            var output = writer.GetStringBuilder().ToString().Trim();

            // Assert
            Assert.Equal("Hello Superman!", output);
        }
    }
}
