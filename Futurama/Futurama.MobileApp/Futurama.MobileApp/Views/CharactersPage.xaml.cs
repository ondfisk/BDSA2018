using Futurama.MobileApp.ViewModels;
using Futurama.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futurama.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharactersPage : ContentPage
    {
        private readonly CharactersViewModel _viewModel;

        public CharactersPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<CharactersViewModel>();

            _viewModel.Navigation = Navigation;
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is CharacterDTO character))
            {
                return;
            }

            await Navigation.PushAsync(new CharacterDetailPage(character));

            // Manually deselect item.
            CharactersListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Characters.Count == 0)
            {
                _viewModel.LoadCommand.Execute(null);
            }
        }
    }
}