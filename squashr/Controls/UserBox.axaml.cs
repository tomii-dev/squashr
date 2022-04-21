using Avalonia.Controls;
using Avalonia.Interactivity;
using squashr.Models;
using Avalonia.Media.Imaging;
using squashr.ViewModels;

namespace squashr.Controls
{
    public partial class UserBox : UserControl
    {
        private TextBlock _usernameText;
        private Image _pfp;
        private Button _button;
        private LocalUser _user;
        public LocalUser User {
            set {
                Update(value);
            } 
        }

        public UserBox()
        {
            DataContext = this;
            InitializeComponent();
            _usernameText = this.Find<TextBlock>("Username");
            _pfp = this.Find<Image>("Pfp");
            _button = this.Find<Button>("Btn");

            _button.Click += OnButtonClick;
        }

        private void OnButtonClick(object? sender, RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new UserDashboardViewModel(_user));
        }

        private void Update(LocalUser user)
        {
            _usernameText.Text = user.Username;
            _pfp.Source = new Bitmap(user.PfpPath);
            _user = user;
        }
    }
}
