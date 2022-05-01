using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Services;
using Avalonia.Interactivity;

namespace squashr.Views
{
    public partial class CreateBugView : UserControl
    {
        private TextBox _bugTitleInput;
        private Slider _severitySlider;
        private Button _createButton;
        public CreateBugView()
        {
            InitializeComponent();
            DataContext = new CreateBugViewModel();
            _bugTitleInput = this.Find<TextBox>("Title");
            _severitySlider = this.Find<Slider>("Severity");
            _createButton = this.Find<Button>("Create");
            _bugTitleInput.KeyUp += (s, e)
                => Events.Invoke(Events.UIEventType.BugTitleInputChanged, s);
            _severitySlider.PropertyChanged += (s, e)
                => Events.Invoke(Events.UIEventType.SeveritySliderChanged, s);
            _createButton.Click += (s, e)
                => Events.Invoke(Events.UIEventType.CreateBugButtonClicked, s);
        }
    }
}
