using Avalonia.Controls;
using squashr.Services;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class CreateLocalUserView : UserControl
    {
        private TextBox _usernameInput;
        private TextBox _passwordInput;
        private Button _createButton;
        public CreateLocalUserView()
        {
            InitializeComponent();
            DataContext = new CreateLocalUserViewModel();
            _usernameInput = this.Find<TextBox>("usernameInput");
            _passwordInput = this.Find<TextBox>("passwordInput");
            _createButton = this.Find<Button>("createButton");

            _usernameInput.KeyUp += (s, e) => Events.Invoke(Events.UIEventType.UsernameInputChanged, s);
            _passwordInput.KeyUp += (s, e) => Events.Invoke(Events.UIEventType.PasswordInputChanged, s);
            _createButton.Click += (s, e) => Events.Invoke(Events.UIEventType.CreateButtonClicked, s);
        }
    }
}
