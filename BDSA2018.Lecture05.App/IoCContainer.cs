using BDSA2018.Lecture05.Entities;
using BDSA2018.Lecture05.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace BDSA2018.Lecture05.App
{
    public static class IoCContainer
    {
        private static IServiceProvider _provider;

        public static IServiceProvider Create()
        {
            return _provider ?? (_provider = ConfigureServices());
        }

        private static IServiceProvider ConfigureServices()
        {
            var settings = GetSettings();

            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<FuturamaContext>(
                options => options.UseSqlServer(settings.ConnectionString))
                .AddTransient<IFuturamaContext, FuturamaContext>()
                .AddTransient<ICharacterRepository, CharacterRepository>();

            return services.BuildServiceProvider();
        }

        private static ISettings GetSettings()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddUserSecrets<Program>(); // This does not work in production...

            var settings = new Settings();

            builder.Build().Bind(settings);

            return settings;
        }
    }
}
