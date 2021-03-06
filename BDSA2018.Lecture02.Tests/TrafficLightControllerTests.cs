﻿using System;
using Xunit;

namespace BDSA2018.Lecture02.Tests
{
    public class TrafficLightControllerTests
    {
        [Fact]
        public void CanIGo_given_Green_returns_True()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo("Green");

            Assert.True(go);
        }

        [Fact]
        public void CanIGo_given_Yellow_returns_False()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo("yellow");

            Assert.False(go);
        }

        [Fact]
        public void CanIGo_given_Red_returns_False()
        {
            var controller = new TrafficLightController();

            var go = controller.MayIGo("RED");

            Assert.False(go);
        }

        [Fact]
        public void CanIGo_given_Invalid_Color_throws_ArgumentException()
        {
            var controller = new TrafficLightController();

            Assert.Throws<ArgumentException>(() => controller.MayIGo("Invalid Color"));
        }

        [Fact]
        public void CanIGo_given_Invalid_Color_throws_with_message_Invalid_Color()
        {
            var controller = new TrafficLightController();

            var exception = Assert.Throws<ArgumentException>(() => controller.MayIGo("Invalid Color"));

            Assert.Equal("Invalid color", exception.Message);
        }
    }
}
