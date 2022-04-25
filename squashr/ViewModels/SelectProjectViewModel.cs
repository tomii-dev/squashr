﻿using Avalonia.Controls;
using Avalonia.Media;
using squashr.Models;
using squashr.Controls;
using squashr.Services;
using System.ComponentModel;
using System;
using System.Collections.Generic;

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
        {
            Console.WriteLine("mhmmmm");
        }

        public void RenderProjects(StackPanel panel)
        {
            if (Data.CurrentUser.Projects != null)
                foreach (Project project in Data.CurrentUser.Projects)
                {
                    Console.WriteLine(project.Name);
                    ProjectBox box = new ProjectBox();
                    box.Project = project;
                    box.Find<TextBlock>("Title").Text = project.Name;
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
