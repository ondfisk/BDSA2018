using Futurama.MobileApp.Models;
using Futurama.MobileApp.ViewModels;
using Futurama.MobileApp.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Futurama.MobileApp
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        private static readonly Uri _backendUrl = new Uri("https://localhost:44326");

        private readonly Lazy<IServiceProvider> _lazyProvider = new Lazy<IServiceProvider>(() => ConfigureServices());

        public IServiceProvider Container => _lazyProvider.Value;

        public App()
        {
            InitializeComponent();

            DependencyResolver.ResolveUsing(type => Container.GetService(type));

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            var handler = new HttpClientHandler();
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
#endif

            services.AddSingleton(_ => new HttpClient(handler) { BaseAddress = _backendUrl });
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<CharactersViewModel>();
            services.AddScoped<CharacterDetailViewModel>();
            services.AddTransient<NewCharacterViewModel>();
            services.AddTransient<EditCharacterViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
