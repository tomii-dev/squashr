using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Controls;
using squashr.Services;

namespace squashr.Views
{
    public partial class BugView : UserControl
    {
        private Button _closeBtn;
        public BugView()
        {
            InitializeComponent();
            BugViewModel vm = new BugViewModel();
            DataContext = vm;
            vm.TitleBlock = this.Find<EditableTextBlock>("TitleBlock");
            _closeBtn = this.Find<Button>("Close");

            _closeBtn.Click += (o, e) => Events.Invoke(Events.RedirectEventType.BugClosed, null);
        }
    }
}
