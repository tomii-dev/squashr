using System.ComponentModel;
using squashr.Models;
using squashr.Controls;
using squashr.Services;
using squashr.Views;
using System;

namespace squashr.ViewModels
{
    public class BugViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Bug _bug;
        private string _title;
        public Bug Bug
        {
            get { return _bug; }
            set { 
                _bug = value;
                Update();
            }
        }
        public string Title {
            get { return _title; }
            set
            {
                _title = value;
            }
        }

        public EditableTextBlock TitleBlock { get; set; }

        public BugViewModel()
        {
            Events.TextBlockEdited += OnTextBlockEdited;
            Events.BugClosed += OnBugClosed;
            Events.ProjectOpened += MainWindowViewModel.OnProjectOpened;
        }

        private void OnTextBlockEdited(object o)
        {
            if (o != TitleBlock) return;
            _title = (o as EditableTextBlock).Text;
        }

        private void OnBugClosed(object o)
        {
            Events.TextBlockEdited -= OnTextBlockEdited;
            Bug temp = _bug;
            temp.Title = _title;
            Data.UpdateBug(_bug, temp);
            Events.Invoke(Events.RedirectEventType.ProjectOpened, Data.GetBugProject(_bug));
        }

        private void Update()
        {
            Title = _bug.Title;
            TitleBlock.Text = _title;
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
