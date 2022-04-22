using Avalonia.Interactivity;
using Avalonia.Controls;
using squashr.Models;
using squashr.Services;

namespace squashr.ViewModels
{
    public class CreateProjectViewModel : ViewModelBase
    {
        private string _projectName;

        public void OnCreateButtonPressed(object sender, RoutedEventArgs e)
        {
            Project project = new Project();
            project.Name = _projectName;
            Data.AddProject(project);
            MainWindowViewModel.InvokeViewChanged(new SelectProjectViewModel());
        }

        public void OnNameInputChange(object sender, RoutedEventArgs e)
        {
            _projectName = (sender as TextBox).Text;
        }
    }
}
