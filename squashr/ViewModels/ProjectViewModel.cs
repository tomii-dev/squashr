using squashr.Models;
using Avalonia.Controls;
using squashr.Services;
using System.ComponentModel;

namespace squashr.ViewModels
{
    public class ProjectViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Project _project;
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnNotifyPropertyChanged("Title");
            }
        }

        public ProjectViewModel() 
            => Events.ProjectOpened += setProject;

        private void Update()
        {
            Title = _project.Name;
        }

        public void setProject(object proj)
        {
            _project = (Project)proj;
            Update();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnNotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged Members
    }
}
