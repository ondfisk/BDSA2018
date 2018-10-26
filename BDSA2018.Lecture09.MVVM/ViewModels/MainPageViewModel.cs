using BDSA2018.Lecture09.MVVM.Model;
using System.Collections.ObjectModel;

namespace BDSA2018.Lecture09.MVVM.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IAlbumRepository _repository;

        public ObservableCollection<Album> Albums { get; private set; }

        public MainPageViewModel(IAlbumRepository repository)
        {
            _repository = repository;

            Initialize();
        }

        private async void Initialize()
        {
            var albums = await _repository.ReadAsync();

            Albums = new ObservableCollection<Album>(albums);
        }
    }
}
