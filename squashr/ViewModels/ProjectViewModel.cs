using squashr.Models;
using squashr.Services;
using squashr.Controls;
using System.ComponentModel;
using System.Collections.Generic;
using System;

namespace squashr.ViewModels
{
    public class ProjectViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Project _project;
        private string _title;
        private List<BugBox> _toDo;
        private List<BugBox> _urgent;
        private List<BugBox> _immediate;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnNotifyPropertyChanged("Title");
            }
        }

        public List<BugBox> ToDo
        {
            get { return _toDo; }
            set
            {
                _toDo = value;
                OnNotifyPropertyChanged("ToDo");
            }
        }
        public List<BugBox> Urgent
        {
            get { return _urgent; }
        }
        public List<BugBox> Immediate { 
            get { return _immediate; } 
        }

        public ProjectViewModel()
        {
            Events.ProjectOpened += setProject;
            _toDo = new List<BugBox>();
        }

        private void Update()
        {
            Title = _project.Name;
            foreach(Bug bug in _project.Bugs)
            {
                Console.WriteLine(bug.Title);
                BugBox bugBox = new BugBox{ Bug = bug };
                switch (bug.Severity)
                {
                    case Bug.BugSeverity.ToDo:
                        ToDo.Add(bugBox);
                        break;
                    case Bug.BugSeverity.Urgent:
                        _urgent.Add(bugBox);
                        break;
                    case Bug.BugSeverity.Immediate:
                        _immediate.Add(bugBox);
                        break;
                        
                }
            }

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
