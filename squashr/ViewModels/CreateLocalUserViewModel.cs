using Avalonia.Interactivity;
using Avalonia.Controls;
using squashr.Models;
using squashr.Services;
using squashr.Views;

namespace squashr.ViewModels
{
    public class CreateLocalUserViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        public CreateLocalUserViewModel()
        {
            Events.UsernameInputChanged += OnUsernameInputChange;
            Events.PasswordInputChanged += OnPasswordInputChange;
            Events.CreateButtonClicked += OnCreateButtonClick;
        }

        public void OnCreateButtonClick(object sender)
        {
            LocalUser localUser = new LocalUser();
            localUser.Username = _username;
            localUser.Password = _password;
            localUser.PfpPath = "usr/pfp/default.png";
            Data.AddLocalUser(localUser);
            Data.CurrentUser = localUser;
            MainWindowViewModel.InvokeViewChanged(new UserDashboardView());
        }

        public void OnUsernameInputChange(object sender)
        {
            _username = (sender as TextBox).Text;
        }

        public void OnPasswordInputChange(object sender)
        {
            _password = (sender as TextBox).Text;
        }
    }
}
