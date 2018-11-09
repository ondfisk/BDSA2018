using System.Windows.Input;

namespace BDSA2018.Lecture10.UwpApp
{
    public interface INavigation
    {
        ICommand GoBackCommand { get; }
        ICommand GoToCharacterPageCommand { get; }
        ICommand GoToCharactersPageCommand { get; }
        ICommand GoToMainPageCommand { get; }
    }
}