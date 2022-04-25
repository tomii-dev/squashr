using Avalonia.Controls;
using Avalonia.Interactivity;
using squashr.ViewModels;
using squashr.Views;

namespace squashr.Controls
{
    public partial class CreateProjectButton : UserControl
    {
        private Button _button;
        public CreateProjectButton()
        {
            InitializeComponent();
            _button = this.Find<Button>("Btn");
            _button.Click += OnButtonClicked;

        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new CreateProjectView());
        }
    }
}
