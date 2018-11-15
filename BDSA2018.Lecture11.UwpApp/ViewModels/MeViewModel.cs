using BDSA2018.Lecture11.UwpApp.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2018.Lecture11.UwpApp.ViewModels
{
    public class MeViewModel : BaseViewModel
    {
        private readonly IGraphRepository _repository;

        private string _id;
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _displayName;
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private string _mobilePhone;
        public string MobilePhone
        {
            get => _mobilePhone;
            set => SetProperty(ref _mobilePhone, value);
        }

        private string _userPrincipalName;
        public string UserPrincipalName
        {
            get => _userPrincipalName;
            set => SetProperty(ref _userPrincipalName, value);
        }

        public ICommand LoadCommand { get; }

        public MeViewModel(INavigation navigation, IGraphRepository repository)
            : base(navigation)
        {
            _repository = repository;

            Title = "Me";

            LoadCommand = new RelayCommand(async _ => await ExecuteLoadCommand());
        }

        private async Task ExecuteLoadCommand()
        {
            if (Loading)
            {
                return;
            }
            Loading = true;

            var user = await _repository.ReadAsync();

            Id = user.Id;
            DisplayName = user.DisplayName;
            MobilePhone = user.MobilePhone;
            UserPrincipalName = user.UserPrincipalName;

            Loading = false;
        }
    }
}
