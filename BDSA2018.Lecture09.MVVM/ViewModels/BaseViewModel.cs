using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BDSA2018.Lecture09.MVVM.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract Task Init();
    }
}
