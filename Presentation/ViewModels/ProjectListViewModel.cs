using System.Collections.Generic;
using System.Linq;
using Presentation.Models;

namespace Presentation.ViewModels
{
    
    public class ProjectListViewModel:ViewModel
    {
        private readonly ProjectStorage projectStorage;

        public ProjectListViewModel(ProjectStorage projectStorage) {
            this.projectStorage = projectStorage;
        }
        public IEnumerable<ProjectViewModel> Projects
        {
            get
            {
                return from project in projectStorage.Projects
                       select new ProjectViewModel(project, this);
            }
        }
        internal void RemoveProject(Project project)
        {
            projectStorage.Projects.Remove(project);
            OnPropertyChanged("Projects");
        }

    }
}
