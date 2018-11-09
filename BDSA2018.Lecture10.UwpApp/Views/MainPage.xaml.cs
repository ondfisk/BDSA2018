using BDSA2018.Lecture10.UwpApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BDSA2018.Lecture10.UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly MainViewModel _vm;

        public MainPage()
        {
            InitializeComponent();

            DataContext = _vm = (Application.Current as App).Container.GetRequiredService<MainViewModel>();
        }
    }
}
