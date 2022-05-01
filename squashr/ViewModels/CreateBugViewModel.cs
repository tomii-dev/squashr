using squashr.Services;
using Avalonia.Controls;
using System.ComponentModel;
using squashr.Models;
using System;

namespace squashr.ViewModels
{
    public class CreateBugViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _title;
        private Bug.BugSeverity _severity;
        private string _severityInput;
        public Project Project { get; set; }
        public string Severity {
            get { return _severityInput; }
            set
            {
                _severityInput = value;
                OnNotifyPropertyChanged("Severity");
            }
        }
        public CreateBugViewModel()
        {
            Events.SeveritySliderChanged += OnSeveritySliderChanged;
            Events.BugTitleInputChanged += OnBugTitleInputChanged;
            Events.CreateBugButtonClicked += OnCreateBugButtonClicked;
            Events.ProjectOpened += MainWindowViewModel.OnProjectOpened;
        }

        private void OnSeveritySliderChanged(object o)
        {
            Slider slider = (Slider)o;
            _severity = (Bug.BugSeverity)slider.Value;
            switch (slider.Value)
            {
                case 0:
                    Severity = "to do :)";
                    break;
                case 1:
                    Severity = "urgent :0";
                    break;
                case 2:
                    Severity = "immediate!!!";
                    break;
            }
        }

        private void OnBugTitleInputChanged(object o)
            => _title = (o as TextBox).Text;

        private void OnCreateBugButtonClicked(object o)
        {
            Data.AddBug(Project, new Bug { Title = _title, Severity = _severity});
            Events.Invoke(Events.RedirectEventType.ProjectOpened, Project);
            Events.CreateBugButtonClicked -= OnCreateBugButtonClicked;
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
