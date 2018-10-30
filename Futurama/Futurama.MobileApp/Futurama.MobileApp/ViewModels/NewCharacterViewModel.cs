using Futurama.MobileApp.Models;
using Futurama.Shared;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Futurama.MobileApp.ViewModels
{
    public class NewCharacterViewModel : BaseViewModel
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IActorRepository _actorRepository;

        public ObservableCollection<ActorDTO> Actors { get; set; }

        private ActorDTO _actor;
        public ActorDTO Actor
        {
            get => _actor;
            set => SetProperty(ref _actor, value);
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

        public NewCharacterViewModel(ICharacterRepository characterRepository, IActorRepository actorRepository)
        {
            _characterRepository = characterRepository;
            _actorRepository = actorRepository;

            Title = "New Character";
            Actors = new ObservableCollection<ActorDTO>();

            CancelCommand = new Command(async () => await Navigation.PopModalAsync());
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            SaveCommand = new Command(async () => await ExecuteSaveCommand());
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

            var toCreate = new CharacterCreateUpdateDTO
            {
                ActorId = Actor.Id,
                Name = Name,
                Species = Species,
                Planet = Planet
            };

            var created = await _characterRepository.CreateAsync(toCreate);

            MessagingCenter.Send(this, "CharacterAdded", created);

            await Navigation.PopModalAsync();

            IsBusy = false;
        }
    }
}
