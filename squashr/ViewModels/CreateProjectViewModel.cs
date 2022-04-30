using Avalonia.Interactivity;
using Avalonia.Controls;
using squashr.Models;
using squashr.Services;
using squashr.Views;
using System;

namespace squashr.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private string _projectName;

        public CreateProjectViewModel()
        {
            Events.ProjectNameInputChange += OnNameInputChange;
            Events.CreateProjectButtonClicked += OnCreateButtonPressed;
        }
        public void OnCreateButtonPressed(object sender)
        {
            Project project = new Project();
            project.Name = _projectName;
            project.Bugs.Add(new Bug { Title = "balls", Severity = Bug.BugSeverity.ToDo });
            Data.AddProject(project);
            MainWindowViewModel.InvokeViewChanged(new SelectProjectView());
        }

        public void OnNameInputChange(object sender)
        {
            _projectName = (sender as TextBox).Text;
        }
    }
}
