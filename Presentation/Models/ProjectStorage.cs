using System.Collections.Generic;

namespace Presentation.Models {
    public class ProjectStorage {
        public ProjectStorage() {
            Projects = new List<Project>();
        }
        public ICollection<Project> Projects { get; private set; }

        public void AddProject(Project project) {
            Projects.Add(project);
        }
    }
}