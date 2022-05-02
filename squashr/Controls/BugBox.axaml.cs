using Avalonia.Controls;
using squashr.Models;
using squashr.Services;

namespace squashr.Controls
{
    public partial class BugBox : UserControl
    {
        private Bug _bug;
        private Button _button;
        private TextBlock _title;
        public Bug Bug { 
            get { return _bug; } 
            set { 
                _bug = value;
                Update();
            }
        }
        public BugBox()
        {
            InitializeComponent();
            _button = this.Find<Button>("Btn");
            _title = this.Find<TextBlock>("Title");

            _button.Click += (o, e) => Events.Invoke(Events.RedirectEventType.BugOpened, _bug);
        }

        private void Update()
        {
            _title.Text = _bug.Title;
        }
    }
}
