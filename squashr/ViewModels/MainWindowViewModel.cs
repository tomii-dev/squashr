using System;
using System.ComponentModel;
using squashr.Services;

namespace squashr.ViewModels
{
    public delegate void ChangeView(ViewModelBase view);
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView {
            get { return _currentView; }
            set 
            {
                _currentView = value;
                OnNotifyPropertyChanged("CurrentView");
            } 
        }
        public static event ChangeView ViewChanged;

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Members

        public MainWindowViewModel()
        {
            if (Data.LocalUsers.Count > 0)
                CurrentView = new SelectUserViewModel();
            else
                CurrentView = new CreateAccountViewModel();
            ViewChanged += ChangeView;
        }

        public static void InvokeViewChanged(ViewModelBase view)
        {
            ViewChanged?.Invoke(view);
        }
        private void ChangeView(ViewModelBase view)
        {
            CurrentView = view;
        }
    }
}
