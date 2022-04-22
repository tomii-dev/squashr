using Avalonia.Controls;
using squashr.ViewModels;

namespace squashr.Views
{
    public partial class CreateProjectView : UserControl
    {
        CreateProjectViewModel vm;
        private Button _createButton;
        private TextBox _nameInput;
        public CreateProjectView()
        {
            InitializeComponent();
            _createButton = this.Find<Button>("CreateBtn");
            _nameInput = this.Find<TextBox>("NameInput");
            vm = (CreateProjectViewModel)DataContext;

            _createButton.Click += vm.OnCreateButtonPressed;
            _nameInput.KeyUp += vm.OnNameInputChange;
        }
    }
}
