using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels
{
    
    public class ProjectListViewModel:ViewModel
    {
        private readonly ProjectStorage projectStorage;
        private NewProjectViewModel newProject;
        public ICommand ShowNewProjectControl { get; private set; }
        public ProjectListViewModel(ProjectStorage projectStorage) {
            this.projectStorage = projectStorage;
            newProject = new NewProjectViewModel(this);
            ShowNewProjectControl = new Command(OnShowNewProjectControl);
        }
        public IEnumerable<ProjectViewModel> Projects
        {
            get
            {
                return from project in projectStorage.Projects
                       select new ProjectViewModel(project, this);
            }
        }
        public NewProjectViewModel NewProject
        {
            get { return newProject; }
        }
        internal void RemoveProject(Project project)
        {
            projectStorage.Projects.Remove(project);
            OnPropertyChanged("Projects");
        }

        internal void AddProject(Project project)
        {
            projectStorage.AddProject(project);
            OnPropertyChanged("Projects");
            newProject = new NewProjectViewModel(this);
            HideNewClientControl();
        }

        public void OnShowNewProjectControl()
        {
            newProject.Visible = Visibility.Visible;
            OnPropertyChanged("NewProject");
        }

        private void HideNewClientControl()
        {
            newProject.Visible = Visibility.Hidden;
            OnPropertyChanged("NewProject");
        }
    }
}
