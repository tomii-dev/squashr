using Avalonia.Controls;
using squashr.ViewModels;
using squashr.Controls;
using squashr.Models;

namespace squashr.Views
{
    public partial class ProjectView : UserControl
    {
        ProjectViewModel vm;
        private StackPanel _panel;

        public ProjectView()
        {
            InitializeComponent();
            _panel = this.Find<StackPanel>("Panel");
            ProjectBox projectBox = new ProjectBox();
            Project project = new Project();
            project.Name = "BALLS";
            projectBox.Project = project;
            _panel.Children.Add(projectBox);
        }
    }
}
