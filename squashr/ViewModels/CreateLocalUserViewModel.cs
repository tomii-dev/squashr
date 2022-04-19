using System;
using Avalonia.Interactivity;
using Avalonia.Controls;
using squashr.Models;
using squashr.Services;
using System.Windows.Media.Imaging;
using Avalonia.Media.Imaging;

namespace squashr.ViewModels
{
    public class CreateLocalUserViewModel : ViewModelBase
    {
        private string _username;
        private string _password;
        public CreateLocalUserViewModel()
        {
        }

        public void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            LocalUser localUser = new LocalUser();
            localUser.Username = _username;
            localUser.Password = _password;
            localUser.PfpPath = "usr/pfp/default.png";
            Data.AddLocalUser(localUser);
            MainWindowViewModel.InvokeViewChanged(new UserDashboardViewModel(localUser));
        }

        public void OnUsernameInputChange(object sender, RoutedEventArgs e)
        {
            _username = (sender as TextBox).Text;
        }

        public void OnPasswordInputChange(object sender, RoutedEventArgs e)
        {
            _password = (sender as TextBox).Text;
        }
    }
}
