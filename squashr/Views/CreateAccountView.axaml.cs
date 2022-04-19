using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class CreateAccountView : UserControl
    {
        CreateAccountViewModel vm;
        private Button _createLocalUserButton;
        private Button _createWebUserButton;

        public CreateAccountView()
        {
            InitializeComponent();

            vm = (CreateAccountViewModel)DataContext;

            _createLocalUserButton = this.Find<Button>("createLocal");
            _createWebUserButton = this.Find<Button>("createWeb");

            _createLocalUserButton.Click += vm.OnLocalUserButtonClicked;
            _createWebUserButton.Click += vm.OnWebUserButtonClicked;
        }
    }
}
