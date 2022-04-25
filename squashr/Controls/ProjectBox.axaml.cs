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
        private Project _project;
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
            _project = project;
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            ProjectViewModel projectView = new ProjectViewModel();
            projectView.Project = _project;
            MainWindowViewModel.InvokeViewChanged(projectView);
        }
    }
}
