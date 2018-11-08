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

        private CharacterDTO _selected;
        public CharacterDTO Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value, nameof(Selected), () =>
            {
                if (Selected != null)
                {
                    Navigation.GoToCharacterPageCommand.Execute(Selected);
                }
            });
        }

        public ObservableCollection<CharacterDTO> Items { get; set; }

        public ICommand AddCommand { get; }
        public ICommand LoadCommand { get; }

        public CharactersViewModel(INavigation navigation, ICharacterRepository repository)
            : base(navigation)
        {
            _repository = repository;

            Title = "Characters";
            Items = new ObservableCollection<CharacterDTO>();

            LoadCommand = new RelayCommand(async _ => await ExecuteLoadCommand());
        }

        private async Task ExecuteLoadCommand()
        {
            if (Loading)
            {
                return;
            }
            Loading = true;

            Items.Clear();

            var characters = await _repository.ReadAsync();

            foreach (var character in characters)
            {
                Items.Add(character);
            }

            Loading = false;
        }
    }
}