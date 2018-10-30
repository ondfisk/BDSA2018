using Futurama.MobileApp.Models;
using Futurama.Shared;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Futurama.MobileApp.ViewModels
{
    public class EditCharacterViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IActorRepository _actorRepository;

        public ObservableCollection<ActorDTO> Actors { get; set; }

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

        private ActorDTO _actor;
        public ActorDTO Actor
        {
            get => _actor;
            set { SetProperty(ref _actor, value); SetProperty(ref _actorId, value.Id); }
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

        public ICommand LoadCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public EditCharacterViewModel(ICharacterRepository characterRepository, IActorRepository actorRepository)
        {
            _characterRepository = characterRepository;
            _actorRepository = actorRepository;

            Actors = new ObservableCollection<ActorDTO>();

            CancelCommand = new Command(async () => await Navigation.PopModalAsync());
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            SaveCommand = new Command(async () => await ExecuteSaveCommand());
        }

        public void Init(CharacterCreateUpdateDTO character)
        {
            Title = $"Update {character.Name}";
            Id = character.Id;
            ActorId = character.ActorId;
            Name = character.Name;
            Planet = character.Planet;
            Species = character.Species;
        }

        private async Task ExecuteLoadCommand()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            Actors.Clear();

            var actors = await _actorRepository.ReadAsync();

            foreach (var actor in actors)
            {
                Actors.Add(actor);

                if (actor.Id == ActorId)
                {
                    Actor = actor;
                }
            }

            IsBusy = false;
        }

        private async Task ExecuteSaveCommand()
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            var toUpdate = new CharacterCreateUpdateDTO
            {
                Id = Id,
                ActorId = ActorId,
                Name = Name,
                Species = Species,
                Planet = Planet
            };

            var updated = await _characterRepository.UpdateAsync(toUpdate);

            MessagingCenter.Send(this, "CharacterUpdated");

            await Navigation.PopModalAsync();

            IsBusy = false;
        }
    }
}
