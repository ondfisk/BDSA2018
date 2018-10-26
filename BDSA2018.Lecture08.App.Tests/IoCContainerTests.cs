using BDSA2018.Lecture08.Models.Facade;
using BDSA2018.Lecture08.Models.IoCContainer;
using BDSA2018.Lecture08.Models.Singleton;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace BDSA2018.Lecture08.App.Tests
{
    public class IoCContainerTests
    {
        [Fact]
        public void Container_can_build_IAnimal()
        {
            var container = IoCContainer.Container;

            var config = container.GetService<IAnimalService>();

            Assert.IsType<AnimalService>(config);

        }

        [Fact]
        public void Instance_configures_IConfig_to_HardcodedConfig()
        {
            var container = IoCContainer.Container;

            var config = container.GetService<IConfig>();

            Assert.IsType<HardcodedConfig>(config);
        }

        [Theory]
        [InlineData(typeof(IArchiver), typeof(Archiver))]
        [InlineData(typeof(IPublisher), typeof(Publisher))]
        public void Instance_configures_intf_to_impl(Type intf, Type impl)
        {
            var container = IoCContainer.Container;

            var instance = container.GetService(intf);

            Assert.IsType(impl, instance);
        }
    }
}
