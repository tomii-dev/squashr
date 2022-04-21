using Avalonia.Controls;
using Avalonia.Interactivity;
using squashr.Models;
using squashr.ViewModels;

namespace squashr.Controls
{
    public partial class ProjectBox : UserControl
    {
        private Button _button;
        private TextBlock _title;
        public Project Project { 
            set { Update(value); }
        }
        public ProjectBox()
        {
            InitializeComponent();
            _button = this.Find<Button>("Btn");
            _title = this.Find<TextBlock>("Title");

            _button.Click += OnButtonClicked;
        }

        private void Update(Project project)
        {
            _title.Text = project.Name;
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.InvokeViewChanged(new ViewModelBase());
        }
    }
}
