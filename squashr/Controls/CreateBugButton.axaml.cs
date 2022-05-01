using Avalonia.Controls;
using squashr.Services;
using squashr.Models;

namespace squashr.Controls
{
    public partial class CreateBugButton : UserControl
    {
        private Button _button;
        public Project Project { get; set; }
        public CreateBugButton()
        {
            InitializeComponent();
            _button = this.Find<Button>("Btn");

            _button.Click += (s, e)
                => Events.Invoke(Events.RedirectEventType.CreateBugPageOpened, Project);
        }
    }
}
