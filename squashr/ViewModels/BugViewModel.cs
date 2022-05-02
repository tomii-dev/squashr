using System.ComponentModel;
using squashr.Models;

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
                OnNotifyPropertyChanged("Title");
            }
        }

        private void Update()
        {
            Title = _bug.Title;
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
