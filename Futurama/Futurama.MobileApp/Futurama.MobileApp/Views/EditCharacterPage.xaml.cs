using Futurama.MobileApp.ViewModels;
using Futurama.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futurama.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditCharacterPage : ContentPage
    {
        private readonly EditCharacterViewModel _viewModel;

        public EditCharacterPage(CharacterCreateUpdateDTO character)
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<EditCharacterViewModel>();
            _viewModel.Navigation = Navigation;
            _viewModel.Init(character);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadCommand.Execute(null);
        }
    }
}