using Presentation.Models;

namespace Presentation.ViewModels
{
    public class ProjectViewModel:ViewModel
    {
        private readonly Project project;
        private readonly ProjectListViewModel parent;
        
        public ProjectViewModel(Project project, ProjectListViewModel parent) {
            this.project = project;
            this.parent = parent;
        }
        public string Name {
            get { return project.Name; }
            set {
                project.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string ClientName {
            get { return project.ClientName; }
            set {
                project.ClientName = value;
                OnPropertyChanged("ClientName");
            }
        }
        public string Status
        {
            get { return project.Status; }
            set
            {
                project.Status = value;
                OnPropertyChanged("Status");
            }
        }
      
    }
}
