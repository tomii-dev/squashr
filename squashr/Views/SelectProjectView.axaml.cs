using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Controls;
using squashr.Models;
using squashr.Services;

namespace squashr.Views
{
    public partial class SelectProjectView : UserControl
    {
        public SelectProjectView()
        {
            InitializeComponent();
            DataContext = new SelectProjectViewModel();
        }
    }
}
