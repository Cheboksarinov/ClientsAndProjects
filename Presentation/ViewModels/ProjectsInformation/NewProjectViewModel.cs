#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ProjectsInformation {
    public class NewProjectViewModel : ViewModel {
        private readonly ProjectListViewModel parent;
        private readonly Project project;
        private ICommand addCommand;
        private string addNewProjectDialogVisible;
        private List<string> avaliableStatusList;

        public NewProjectViewModel(ProjectListViewModel parent) {
            this.parent = parent;
            project = new Project {ClientName = "", Name = "", Status = ""};
            avaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
            EndDate = "No end date";
            if (project.EndDate == "No end date") {
                AvaliableStatusList.Remove("Закончен");
            }
            addNewProjectDialogVisible = "Hidden";
            Status = AvaliableStatusList.First();
        }

        public string Name {
            get { return project.Name; }
            set {
                project.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<string> AvaliableStatusList {
            get {
                avaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
                if (EndDate != "No end date") return avaliableStatusList;
                avaliableStatusList.Remove("Закончен");
                if (Status != "Закончен") return avaliableStatusList;
                Status = "Первичный контакт";
                OnPropertyChanged("Status");
                return avaliableStatusList;
            }
        }

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

        public string EndDate {
            get { return project.EndDate; }
            set {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) {
                    value = "No end date";
                }
                project.EndDate = value;
                OnPropertyChanged("EndDate");
                OnPropertyChanged("AvaliableStatusList");
            }
        }

        public string AddNewProjectDialogVisible {
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