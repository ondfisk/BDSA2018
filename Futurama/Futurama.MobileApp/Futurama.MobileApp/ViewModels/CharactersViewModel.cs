using Futurama.MobileApp.Models;
using Futurama.MobileApp.Views;
using Futurama.Shared;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Futurama.MobileApp.ViewModels
{
    public class CharactersViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _repository;

        public ObservableCollection<CharacterDTO> Characters { get; set; }

        public ICommand AddCommand { get; set; }
        public ICommand LoadCommand { get; set; }

        public CharactersViewModel(ICharacterRepository repository)
        {
            _repository = repository;

            Title = "Characters";
            Characters = new ObservableCollection<CharacterDTO>();

            AddCommand = new Command(async () => await Navigation.PushModalAsync(new NavigationPage(new NewCharacterPage())));
            LoadCommand = new Command(async () => await ExecuteLoadCommand());

            MessagingCenter.Subscribe<NewCharacterViewModel, CharacterDTO>(this, "CharacterAdded", (obj, character) =>
            {
                Characters.Add(character);
            });
            MessagingCenter.Subscribe<EditCharacterViewModel>(this, "CharacterUpdated", async obj =>
            {
                await ExecuteLoadCommand();
            });
            MessagingCenter.Subscribe<CharacterDetailViewModel>(this, "CharacterDeleted", async obj =>
            {
                await ExecuteLoadCommand();
            });
        }

        private async Task ExecuteLoadCommand()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            Characters.Clear();

            var characters = await _repository.ReadAsync();

            foreach (var character in characters)
            {
                Characters.Add(character);
            }

            IsBusy = false;
        }
    }
}