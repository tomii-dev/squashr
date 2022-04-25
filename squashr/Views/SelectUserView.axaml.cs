using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class SelectUserView : UserControl
    {
        private StackPanel _userList;
        public SelectUserView()
        {
            InitializeComponent();
            DataContext = new SelectUserViewModel();
        }
    }
}
