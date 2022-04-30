using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Views;

namespace squashr.Controls
{
    public partial class Navbar : UserControl
    {
        private Button _bugBtn;
        public Navbar()
        {
            InitializeComponent();
            _bugBtn = this.Find<Button>("BugBtn");
            _bugBtn.Click += (o, e) 
                => MainWindowViewModel.InvokeViewChanged(new UserDashboardView());
        }
    }
}
