using squashr.Models;

namespace squashr.ViewModels
{
    public class ProjectViewModel : ViewModelBase
    {
        private Project _project;
        public string Title { get; set; }
        public Project Project
        {
            get { return _project; }
            set { 
                _project = value;
                Update();
            }
        }

        private void Update()
        {
            Title = _project.Name;
        }
    }
}
