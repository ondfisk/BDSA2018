using BDSA2018.Lecture10.UwpApp.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace BDSA2018.Lecture10.UwpApp.ViewModels
{
    public class LogViewModel : BaseViewModel
    {
        private readonly ISettings _settings;
        private readonly HttpClientHandler _handler;

        public ObservableCollection<Message> Items { get; set; }

        private readonly HubConnection _connection;

        public ICommand LoadCommand { get; }

        public LogViewModel(INavigation navigation, ISettings settings, HttpClientHandler handler)
            : base(navigation)
        {
            _settings = settings;
            _handler = handler;

            Title = "Log";
            Items = new ObservableCollection<Message>();

            _connection = new HubConnectionBuilder()
               .WithUrl(new Uri(_settings.BackendUrl, "hubs/log"), o => {
                   o.HttpMessageHandlerFactory = h => _handler;
               })
               .Build();

            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _connection.StartAsync();
            };
            _connection.On<string>("ReceiveMessage", async message =>
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                () =>
                {
                    Items.Add(new Message { Text = message });
                });
            });

            LoadCommand = new RelayCommand(async _ => await ExecuteLoadCommand());
        }

        private async Task ExecuteLoadCommand()
        {
            if (Loading)
            {
                return;
            }
            Loading = true;

            Items.Clear();

            await _connection.StartAsync();

            Loading = false;
        }
    }
}