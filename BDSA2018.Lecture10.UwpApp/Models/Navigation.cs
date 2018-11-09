using BDSA2018.Lecture10.UwpApp.Models;
using BDSA2018.Lecture10.UwpApp.Views;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace BDSA2018.Lecture10.UwpApp
{
    public class Navigation : INavigation
    {
        private readonly Frame _frame;

        public Navigation(Frame frame)
        {
            _frame = frame;

            GoBackCommand = new RelayCommand(p => { if (_frame.CanGoBack) { _frame.GoBack(); } });
            GoToMainPageCommand = new RelayCommand(p => _frame.Navigate(typeof(MainPage), p));
            GoToCharactersPageCommand = new RelayCommand(p => _frame.Navigate(typeof(CharactersPage), p));
            GoToCharacterPageCommand = new RelayCommand(p => _frame.Navigate(typeof(CharacterPage), p));
            GoToLogPageCommand = new RelayCommand(p => _frame.Navigate(typeof(LogPage), p));
        }

        public ICommand GoBackCommand { get; }

        public ICommand GoToMainPageCommand { get; }

        public ICommand GoToCharactersPageCommand { get; }

        public ICommand GoToCharacterPageCommand { get; }

        public ICommand GoToLogPageCommand { get; }
    }
}