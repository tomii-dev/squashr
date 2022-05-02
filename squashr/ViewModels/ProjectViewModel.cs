using squashr.Models;
using squashr.Services;
using squashr.Controls;
using squashr.Views;
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

        public Project Project
        {
            set { 
                _project = value;
                Update();
            }
        }
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
            set
            {
                _urgent = value;
                OnNotifyPropertyChanged("Urgent");
            }
        }
        public List<BugBox> Immediate { 
            get { return _immediate; }
            set
            {
                _immediate = value;
                OnNotifyPropertyChanged("Immediate");
            }
        }

        public ProjectViewModel()
        {
            _toDo = new List<BugBox>();
            _urgent = new List<BugBox>();
            _immediate = new List<BugBox>();
            Events.CreateBugPageOpened += OnCreateBugPageOpened;
            Events.BugOpened += OnBugOpened;
        }

        private void OnBugOpened(object o)
        {
            BugView view = new BugView();
            BugViewModel vm = (BugViewModel)view.DataContext;
            vm.Bug = (Bug)o;
            MainWindowViewModel.InvokeViewChanged(view);
            Events.BugOpened -= OnBugOpened; 
        }
        private void OnCreateBugPageOpened(object o)
        {
            CreateBugView view = new CreateBugView();
            CreateBugViewModel vm = (CreateBugViewModel)view.DataContext;
            vm.Project = _project;
            MainWindowViewModel.InvokeViewChanged(view);
            Events.CreateBugPageOpened -= OnCreateBugPageOpened;
        }
        private void Update()
        {
            Title = _project.Name;
            foreach(Bug bug in _project.Bugs)
            {
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
