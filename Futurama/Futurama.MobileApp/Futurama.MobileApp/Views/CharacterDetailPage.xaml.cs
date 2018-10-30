using Futurama.MobileApp.ViewModels;
using Futurama.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futurama.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {
        private readonly CharacterDetailViewModel _viewModel;

        public CharacterDetailPage(CharacterDTO character)
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<CharacterDetailViewModel>();

            _viewModel.Navigation = Navigation;
            _viewModel.Init(character, () => DisplayAlert("Delete?", "Are you sure", "OK", "Cancel"));
        }
    }
}