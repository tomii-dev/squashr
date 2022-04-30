using Avalonia.Controls;
using Avalonia.Media;
using squashr.Models;
using squashr.Controls;
using squashr.Services;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using squashr.Views;
using squashr.ViewModels;

namespace squashr.ViewModels
{
    public class SelectProjectViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _title;
        public string Title { 
            get{
                string username = Data.CurrentUser.Username;
                return username[username.Length - 1] == 's' ? $"{username}' projects" :
                    $"{username}'s projects";
            }
        }

        public List<Control> Projects { 
            get{
                List<Control> projects = new List<Control>();
                int i = 0;
                foreach(Project project in Data.CurrentUser.Projects)
                {
                    ++i;
                    ProjectBox box = new ProjectBox();
                    box.Project = project;
                    projects.Add(box);
                }
                projects.Add(new CreateProjectButton());
                return projects;
            } 
        }

        public SelectProjectViewModel()
            => Events.ProjectOpened += (o) => {
                ProjectView view = new ProjectView();
                ProjectViewModel vm = (ProjectViewModel)view.DataContext;
                vm.setProject(o);
                MainWindowViewModel.InvokeViewChanged(view);
            };

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
