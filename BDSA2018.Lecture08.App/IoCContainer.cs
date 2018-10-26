using BDSA2018.Lecture08.Models.Facade;
using BDSA2018.Lecture08.Models.IoCContainer;
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
            serviceCollection.AddTransient<IAnimal, Wolf>();
            serviceCollection.AddTransient<IAnimalService, AnimalService>();
            serviceCollection.AddTransient<IArchiver, Archiver>();
            serviceCollection.AddTransient<IPublisher, Publisher>();
            serviceCollection.AddTransient<IPeopleRepository, PeopleRepository>();
            serviceCollection.AddTransient<INotifier, Notifier>();
            serviceCollection.AddSingleton<IConfig, HardcodedConfig>(_ => HardcodedConfig.Instance);
            serviceCollection.AddTransient<Facade>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
