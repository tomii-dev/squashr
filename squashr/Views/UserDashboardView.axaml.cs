using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Services;
using squashr.Models;

namespace squashr.Views
{
    public partial class UserDashboardView : UserControl
    {

        private Button _bugButton;

        public UserDashboardView()
        {
            InitializeComponent();
            DataContext = new UserDashboardViewModel();
            _bugButton = this.Find<Button>("bugBtn");

            _bugButton.Click += OnBugButtonClick;
        }

        private void OnBugButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new SelectProjectView());
        }
    }
}
