using Avalonia.Controls;
using squashr.Models;

namespace squashr.Controls
{
    public partial class BugBox : UserControl
    {
        private Bug _bug;
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
            _title = this.Find<TextBlock>("Title");
        }

        private void Update()
        {
            _title.Text = _bug.Title;
        }
    }
}
