#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ProjectsInformation {
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
            HideNewProjectControl();
        }

        public void OnShowNewProjectControl() {
            NewProject.AddNewProjectDialogVisible = "Visible";
            OnPropertyChanged("NewProject");
        }

        private void HideNewProjectControl() {
            NewProject.AddNewProjectDialogVisible ="Hidden";
            OnPropertyChanged("NewProject");
        }
    }
}