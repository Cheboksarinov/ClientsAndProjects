#region Usings

using System.Collections.Generic;

#endregion

namespace Presentation.Models {
    public class ProjectStorage {
        public ProjectStorage() {
            Projects = new List<Project>();
        }

        public ICollection<Project> Projects { get; }

        public void AddProject(Project project) {
            Projects.Add(project);
        }
    }
}