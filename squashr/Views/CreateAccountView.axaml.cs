using Avalonia.Controls;
using squashr.Services;
using squashr.ViewModels;
using System;

namespace squashr.Views
{
    public partial class CreateAccountView : UserControl
    {
        private Button _createLocalUserButton;
        private Button _createWebUserButton;

        public CreateAccountView()
        {
            InitializeComponent();
            DataContext = new CreateAccountViewModel();

            _createLocalUserButton = this.Find<Button>("createLocal");
            _createWebUserButton = this.Find<Button>("createWeb");

            _createLocalUserButton.Click += (o, e) => 
                Events.Invoke(Events.UIEventType.LocalUserButtonClicked, o);
        }
    }
}
