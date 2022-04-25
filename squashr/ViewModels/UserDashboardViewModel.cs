using squashr.Services;

namespace squashr.ViewModels
{
    public class UserDashboardViewModel : ViewModelBase
    {
        public string WelcomeMessage { get; set; }

        public UserDashboardViewModel()
        {
            WelcomeMessage = $"welcome back, {Data.CurrentUser.Username}";
        }
    }
}
