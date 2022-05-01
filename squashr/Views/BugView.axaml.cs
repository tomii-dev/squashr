using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class BugView : UserControl
    {
        public BugView()
        {
            InitializeComponent();
            DataContext = new BugViewModel();
        }
    }
}
