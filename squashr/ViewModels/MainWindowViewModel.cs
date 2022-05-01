using System;
using System.ComponentModel;
using squashr.Services;
using squashr.Views;
using Avalonia.Controls;

namespace squashr.ViewModels
{
    public delegate void ChangeView(Control view);
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Control _currentView;
        public Control CurrentView {
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
            Events.Setup();
            if (Data.LocalUsers.Count > 0)
                CurrentView = new SelectUserView();
            else
                CurrentView = new CreateAccountView();
            ViewChanged += ChangeView;
            Events.ProjectOpened += OnProjectOpened;
        }

        public static void OnProjectOpened(object o)
        {
            ProjectView view = new ProjectView();
            ProjectViewModel vm = (ProjectViewModel)view.DataContext;
            vm.setProject(o);
            InvokeViewChanged(view);
            Events.ProjectOpened -= OnProjectOpened;
        }

        public static void InvokeViewChanged(Control view)
        {
            ViewChanged?.Invoke(view);
        }
        private void ChangeView(Control view)
        {
            CurrentView = view;
        }
    }
}
