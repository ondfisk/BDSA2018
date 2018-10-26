using BDSA2018.Lecture08.Models.Singleton;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace BDSA2018.Lecture08.App.Tests
{
    public class IoCContainerTests
    {
        [Fact]
        public void Instance_configures_IConfig_to_HardcodedConfig()
        {
            var container = IoCContainer.Container;

            var config = container.GetService<IConfig>();

            Assert.IsType<HardcodedConfig>(config);
        }

        [Theory]
        [InlineData(typeof(IConfig), typeof(HardcodedConfig))]
        public void Instance_configures_intf_to_impl(Type intf, Type impl)
        {
            var container = IoCContainer.Container;

            var instance = container.GetService(intf);

            Assert.IsType(impl, instance);
        }
    }
}
