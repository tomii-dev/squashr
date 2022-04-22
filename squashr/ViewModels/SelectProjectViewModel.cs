using Avalonia.Controls;
using Avalonia.Media;
using squashr.Models;
using squashr.Controls;
using squashr.Services;
using System.ComponentModel;
using System;

namespace squashr.ViewModels
{
    public class SelectProjectViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _title;
        public string Title { 
            get { return _title; }
            set {
                _title = value; 
                OnNotifyPropertyChanged("Title");
            } 
        }
        public SelectProjectViewModel()
        {
            Title = $"{Data.CurrentUser.Username}'s projects";
        }

        public void RenderProjects(StackPanel panel)
        {
            if (Data.CurrentUser.Projects != null)
                foreach (Project project in Data.CurrentUser.Projects)
                {
                    ProjectBox box = new ProjectBox();
                    box.Project = project;
                    panel.Children.Add(box);
                }
            panel.Children.Add(new CreateProjectButton());
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
