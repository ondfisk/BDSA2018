using Futurama.MobileApp.Models;
using Futurama.MobileApp.Views;
using Futurama.Shared;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Futurama.MobileApp.ViewModels
{
    public class CharacterDetailViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _repository;

        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private int? _actorId;
        public int? ActorId
        {
            get => _actorId;
            set => SetProperty(ref _actorId, value);
        }

        private string _actorName;
        public string ActorName
        {
            get => _actorName;
            set => SetProperty(ref _actorName, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _planet;
        public string Planet
        {
            get => _planet;
            set => SetProperty(ref _planet, value);
        }

        private string _species;
        public string Species
        {
            get => _species;
            set => SetProperty(ref _species, value);
        }

        private int _numberOfEpisodes;
        public int NumberOfEpisodes
        {
            get => _numberOfEpisodes;
            set => SetProperty(ref _numberOfEpisodes, value);
        }

        public ICommand LoadCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public CharacterDetailViewModel(ICharacterRepository repository)
        {
            _repository = repository;

            EditCommand = new Command(async () => await Navigation.PushModalAsync(new NavigationPage(new EditCharacterPage(new CharacterCreateUpdateDTO
            {
                Id = Id,
                ActorId = ActorId,
                Name = Name,
                Species = Species,
                Planet = Planet
            }))));

            DeleteCommand = new Command(async () =>
            {
                if (await _confirm())
                {
                    await _repository.DeleteAsync(Id);
                    MessagingCenter.Send(this, "CharacterDeleted");
                    await Navigation.PopAsync();
                }
            });

            MessagingCenter.Subscribe<EditCharacterViewModel>(this, "CharacterUpdated", async obj =>
            {
                await ExecuteLoadCommand();
            });
        }

        private Func<Task<bool>> _confirm;

        public void Init(CharacterDTO character, Func<Task<bool>> confirm = null)
        {
            Title = character.Name;
            Id = character.Id;
            ActorId = character.ActorId;
            ActorName = character.ActorName;
            Name = character.Name;
            Planet = character.Planet;
            Species = character.Species;
            NumberOfEpisodes = character.NumberOfEpisodes;

            if (confirm != null)
            {
                _confirm = confirm;
            }
        }

        private async Task ExecuteLoadCommand()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            var character = await _repository.FindAsync(Id);

            Init(character);

            IsBusy = false;
        }
    }
}
