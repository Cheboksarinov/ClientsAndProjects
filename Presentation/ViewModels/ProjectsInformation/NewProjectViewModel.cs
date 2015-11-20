#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ProjectsInformation {
    public class NewProjectViewModel : ViewModel {
        private readonly ProjectListViewModel parent;
        private readonly Project project;
        private ICommand addCommand;
        private Visibility addNewProjectDialogVisible;

        public NewProjectViewModel(ProjectListViewModel parent) {
            this.parent = parent;
            project = new Project {ClientName = "", Name = "", Status = ""};
            AvaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
            addNewProjectDialogVisible = Visibility.Hidden;
            Status = AvaliableStatusList.First();
        }

        public string Name {
            get { return project.Name; }
            set {
                project.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<string> AvaliableStatusList { get; }

        public string ClientName {
            get { return project.ClientName; }
            set {
                project.ClientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        public string Status {
            get { return project.Status; }
            set {
                project.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public Visibility AddNewProjectDialogVisible {
            get { return addNewProjectDialogVisible; }
            set {
                addNewProjectDialogVisible = value;
                OnPropertyChanged("AddNewProjectDialogVisible");
            }
        }

        public ICommand Add {
            get { return addCommand ?? (addCommand = new Command(() => parent.AddProject(project))); }
        }
    }
}