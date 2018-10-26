using BDSA2018.Lecture09.MVVM.ViewModels;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace BDSA2018.Lecture09.MVVM
{
    public sealed partial class MainPage : Page
    {
        private readonly MainPageViewModel _vm;

        public MainPage()
        {
            InitializeComponent();

            _vm = (Application.Current as App).Container.GetService<MainPageViewModel>();
            DataContext = _vm;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await _vm.Init();
        }
    }
}
