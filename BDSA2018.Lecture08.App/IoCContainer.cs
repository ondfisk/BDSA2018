using BDSA2018.Lecture08.Models.Singleton;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BDSA2018.Lecture08.App
{
    public class IoCContainer
    {
        private static readonly Lazy<IServiceProvider> _lazyProvider = new Lazy<IServiceProvider>(() => ConfigureServices());

        public static IServiceProvider Container { get => _lazyProvider.Value; }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            // Register services here

            return serviceCollection.BuildServiceProvider();
        }
    }
}
