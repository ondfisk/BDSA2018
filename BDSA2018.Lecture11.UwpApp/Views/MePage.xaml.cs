using BDSA2018.Lecture11.UwpApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BDSA2018.Lecture11.UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MePage : Page
    {
        private readonly MeViewModel _vm;

        public MePage()
        {
            InitializeComponent();

            DataContext = _vm = (Application.Current as App).Container.GetRequiredService<MeViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.LoadCommand.Execute(e.Parameter);

            base.OnNavigatedTo(e);
        }
    }
}
