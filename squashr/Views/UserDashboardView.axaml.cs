using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class UserDashboardView : UserControl
    {
        private Button _bugButton;

        public UserDashboardView()
        {
            InitializeComponent();
            _bugButton = this.Find<Button>("bugBtn");

            _bugButton.Click += _bugButton_Click;
        }

        private void _bugButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new ProjectViewModel());
        }
    }
}
