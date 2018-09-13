using System;
using Xunit;
using static BDSA2018.Lecture03.TrafficLightColor;

namespace BDSA2018.Lecture03.Tests
{
    public class TrafficLightControllerTests
    {
        [Fact]
        public void CanIGo_given_Green_returns_True()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo(Green);

            Assert.True(go);
        }

        [Fact]
        public void CanIGo_given_Yellow_returns_False()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo(Yellow);

            Assert.False(go);
        }

        [Fact]
        public void CanIGo_given_Red_returns_False()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo(Red);

            Assert.False(go);
        }

        [Fact]
        public void CanIGo_given_42_throws_ArgumentException()
        {
            var controller = new TrafficLightController();

            Assert.Throws<ArgumentException>(() => controller.MayIGo((TrafficLightColor)42));
        }

        [Fact]
        public void CanIGo_given_42_throws_with_message_Invalid_Color()
        {
            var controller = new TrafficLightController();

            var exception = Assert.Throws<ArgumentException>(() => controller.MayIGo((TrafficLightColor)4));

            Assert.Equal("Invalid color", exception.Message);
        }
    }
}
