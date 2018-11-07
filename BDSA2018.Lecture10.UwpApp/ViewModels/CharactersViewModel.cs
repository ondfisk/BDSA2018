using BDSA2018.Lecture10.Shared;
using BDSA2018.Lecture10.UwpApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2018.Lecture10.UwpApp.ViewModels
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

            LoadCommand = new RelayCommand(async _ => await ExecuteLoadCommand());
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