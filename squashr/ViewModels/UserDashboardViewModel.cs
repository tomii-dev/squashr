using squashr.Views;
using squashr.Models;
using Avalonia.Interactivity;

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
