using BDSA2018.Lecture11.Shared;
using BDSA2018.Lecture11.UwpApp.Models;
using System.Windows.Input;

namespace BDSA2018.Lecture11.UwpApp.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
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

        public ICommand LoadCommand { get; }

        public CharacterViewModel(INavigation navigation)
            : base(navigation)
        {
            LoadCommand = new RelayCommand(p => ExecuteLoadCommand(p));
        }

        private void ExecuteLoadCommand(object parameter)
        {
            if (parameter is CharacterDTO character)
            {
                Title = character.Name;
                Id = character.Id;
                ActorId = character.ActorId;
                ActorName = character.ActorName;
                Name = character.Name;
                Planet = character.Planet;
                Species = character.Species;
                NumberOfEpisodes = character.NumberOfEpisodes;
            }
        }
    }
}
