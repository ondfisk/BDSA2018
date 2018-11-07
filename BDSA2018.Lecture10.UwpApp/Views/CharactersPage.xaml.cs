using BDSA2018.Lecture10.UwpApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BDSA2018.Lecture10.UwpApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CharactersPage : Page
    {
        private readonly CharactersViewModel _vm;

        public CharactersPage()
        {
            InitializeComponent();

            DataContext = _vm = (Application.Current as App).Container.GetRequiredService<CharactersViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm.LoadCommand.Execute(null);

            base.OnNavigatedTo(e);
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems.FirstOrDefault();
            if (item != null)
            {
                Frame.Navigate(typeof(CharacterPage), item);
            }
        }
    }
}
