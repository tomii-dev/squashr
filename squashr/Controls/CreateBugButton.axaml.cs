using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Views;

namespace squashr.Controls
{
    public partial class CreateBugButton : UserControl
    {
        private Button _button;
        public CreateBugButton()
        {
            InitializeComponent();
            _button = this.Find<Button>("Btn");

            _button.Click += (s, e) => MainWindowViewModel.InvokeViewChanged(new CreateBugView());
        }
    }
}
