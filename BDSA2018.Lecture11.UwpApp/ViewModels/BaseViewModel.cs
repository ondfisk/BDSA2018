using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BDSA2018.Lecture11.UwpApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _loading = false;
        public bool Loading
        {
            get => _loading;
            set => SetProperty(ref _loading, value);
        }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public INavigation Navigation { get; }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = null,
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }
            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
    }
}
