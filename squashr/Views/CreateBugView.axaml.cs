using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Services;
using Avalonia.Interactivity;

namespace squashr.Views
{
    public partial class CreateBugView : UserControl
    {
        private Slider _severitySlider;
        public CreateBugView()
        {
            InitializeComponent();
            DataContext = new CreateBugViewModel();
            _severitySlider = this.Find<Slider>("Severity");
            _severitySlider.PropertyChanged += (s, e)
                => Events.Invoke(Events.UIEventType.SeveritySliderChange, s);
        }
    }
}
