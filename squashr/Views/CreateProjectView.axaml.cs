using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class CreateProjectView : UserControl
    {
        CreateProjectViewModel vm;
        public CreateProjectView()
        {
            InitializeComponent();
            vm = (CreateProjectViewModel)DataContext;
        }
    }
}
