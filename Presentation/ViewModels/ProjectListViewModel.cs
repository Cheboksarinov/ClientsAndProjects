using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels {
    public class ProjectListViewModel : ViewModel {
        private readonly ProjectStorage projectStorage;

        public ProjectListViewModel(ProjectStorage projectStorage) {
            this.projectStorage = projectStorage;
            NewProject = new NewProjectViewModel(this);
            ShowNewProjectControl = new Command(OnShowNewProjectControl);
        }

        public ICommand ShowNewProjectControl { get; private set; }

        public IEnumerable<ProjectViewModel> Projects {
            get {
                return from project in projectStorage.Projects
                    select new ProjectViewModel(project, this);
            }
        }

        public NewProjectViewModel NewProject { get; private set; }

        internal void RemoveProject(Project project) {
            projectStorage.Projects.Remove(project);
            OnPropertyChanged("Projects");
        }

        internal void AddProject(Project project) {
            projectStorage.AddProject(project);
            OnPropertyChanged("Projects");
            NewProject = new NewProjectViewModel(this);
            HideNewClientControl();
        }

        public void OnShowNewProjectControl() {
            NewProject.Visible = Visibility.Visible;
            OnPropertyChanged("NewProject");
        }

        private void HideNewClientControl() {
            NewProject.Visible = Visibility.Hidden;
            OnPropertyChanged("NewProject");
        }
    }
}