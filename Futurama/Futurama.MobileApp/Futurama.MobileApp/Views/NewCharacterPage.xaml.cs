using Futurama.MobileApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Futurama.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCharacterPage : ContentPage
    {
        private readonly NewCharacterViewModel _viewModel;

        public NewCharacterPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = DependencyService.Resolve<NewCharacterViewModel>();
            _viewModel.Navigation = Navigation;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Actors.Count == 0)
            {
                _viewModel.LoadCommand.Execute(null);
            }
        }
    }
}