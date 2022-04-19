using Avalonia.Controls;
using squashr.Models;
using squashr.Services;
using squashr.Controls;
using squashr.ViewModels;


namespace squashr.Views
{
    public partial class SelectUserView : UserControl
    {
        SelectUserViewModel vm;
        private StackPanel _userList;
        public SelectUserView()
        {
            InitializeComponent();
            vm = (SelectUserViewModel)DataContext;
            _userList = this.Find<StackPanel>("UserList");
            vm.RenderUsers(_userList);
        }
    }
}
