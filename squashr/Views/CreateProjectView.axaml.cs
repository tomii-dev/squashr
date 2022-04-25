using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Services;

namespace squashr.Views
{
    public partial class CreateProjectView : UserControl
    {
        private Button _createButton;
        private TextBox _nameInput;
        public CreateProjectView()
        {
            InitializeComponent();
            DataContext = new CreateProjectViewModel();
            _createButton = this.Find<Button>("CreateBtn");
            _nameInput = this.Find<TextBox>("NameInput");

            _createButton.Click += (s, e) => Events.Invoke(Events.UIEventType.CreateProjectButtonClicked, s);
            _nameInput.KeyUp += (s, e) => Events.Invoke(Events.UIEventType.ProjectNameInputChange, s);
        }
    }
}
