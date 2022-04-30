using squashr.Services;
using Avalonia.Controls;
using System.ComponentModel;
using System;

namespace squashr.ViewModels
{
    public class CreateBugViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private string _severity;
        public string Severity {
            get { return _severity; }
            set
            {
                _severity = value;
                OnNotifyPropertyChanged("Severity");
            }
        }
        public CreateBugViewModel()
        {
            Events.SeveritySliderChange += OnSeveritySliderChanged;
        }

        private void OnSeveritySliderChanged(object o)
        {
            Slider slider = (Slider)o;
            switch (slider.Value)
            {
                case 0:
                    Severity = "to do :)";
                    break;
                case 1:
                    Severity = "urgent :0";
                    break;
                case 2:
                    Severity = "requires immediate action!!!";
                    break;
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
