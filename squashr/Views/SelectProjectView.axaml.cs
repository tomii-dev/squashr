using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Controls;
using squashr.Models;
using squashr.Services;

namespace squashr.Views
{
    public partial class SelectProjectView : UserControl
    {
        SelectProjectViewModel vm;
        private StackPanel _panel;
        public SelectProjectView()
        {
            InitializeComponent();

            _panel = this.Find<StackPanel>("Panel");
            vm = (SelectProjectViewModel)DataContext;

            vm.RenderProjects(_panel);

            string username = Data.CurrentUser.Username;
            vm.Title =
                username[username.Length - 1] == 's' ? $"{username}' projects" :
                $"{username}'s projects";
        }
    }
}
