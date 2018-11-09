using BDSA2018.Lecture10.UwpApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BDSA2018.Lecture10.UwpApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigation navigation)
            : base(navigation)
        {
            Title = "Futurama";
        }
    }
}
