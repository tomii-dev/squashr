using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Controls;

namespace squashr.Views
{
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
            DataContext = new ProjectViewModel();
        }
    }
}
