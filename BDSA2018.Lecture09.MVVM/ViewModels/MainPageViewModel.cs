using BDSA2018.Lecture09.MVVM.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BDSA2018.Lecture09.MVVM.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IAlbumRepository _repository;

        private ObservableCollection<Album> _albums;
        public ObservableCollection<Album> Albums
        {
            get => _albums;
            set { if (_albums != value) { _albums = value; OnPropertyChanged(); } }
        }

        public MainPageViewModel(IAlbumRepository repository)
        {
            _repository = repository;
        }

        public override async Task Init()
        {
            var albums = await _repository.ReadAsync();

            Albums = new ObservableCollection<Album>(albums);
        }
    }
}
