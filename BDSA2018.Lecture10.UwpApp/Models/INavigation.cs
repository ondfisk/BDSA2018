using System.Windows.Input;

namespace BDSA2018.Lecture10.UwpApp
{
    public interface INavigation
    {
        ICommand GoToCharacterPageCommand { get; }
        ICommand GoToCharactersPageCommand { get; }
        ICommand GoToMainPageCommand { get; }
        ICommand GoToLogPageCommand { get; }
    }
}