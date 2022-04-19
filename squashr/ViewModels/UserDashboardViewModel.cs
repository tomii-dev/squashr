using squashr.Views;
using squashr.Models;
using System.ComponentModel;

namespace squashr.ViewModels
{
    public class UserDashboardViewModel : ViewModelBase
    {
        public string WelcomeMessage { get; set; }
        public UserDashboardViewModel(LocalUser user)
        {
            WelcomeMessage = $"welcome back, {user.Username}";
        }
    }
}
