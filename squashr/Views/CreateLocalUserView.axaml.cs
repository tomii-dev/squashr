using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class CreateLocalUserView : UserControl
    {
        CreateLocalUserViewModel vm;
        private TextBox _usernameInput;
        private TextBox _passwordInput;
        private Button _createButton;
        public CreateLocalUserView()
        {
            InitializeComponent();
            vm = (CreateLocalUserViewModel)DataContext;
            _usernameInput = this.Find<TextBox>("usernameInput");
            _passwordInput = this.Find<TextBox>("passwordInput");
            _createButton = this.Find<Button>("createButton");

            _usernameInput.KeyUp += vm.OnUsernameInputChange;
            _passwordInput.KeyUp += vm.OnPasswordInputChange;
            _createButton.Click += vm.OnCreateButtonClick;
        }
    }
}
