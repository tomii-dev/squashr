using Avalonia.Controls;
using squashr.ViewModels;

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
