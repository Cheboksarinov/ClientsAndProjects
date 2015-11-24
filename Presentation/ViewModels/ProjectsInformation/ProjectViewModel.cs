#region Usings

using System.Collections.Generic;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ProjectsInformation {
    public class ProjectViewModel : ViewModel {
        private readonly ProjectListViewModel parent;
        private readonly Project project;
        private ICommand removeCommand;
        private string statusChangeMode;
        private string statusDisplayMode;

        public ProjectViewModel(Project project, ProjectListViewModel parent) {
            this.project = project;
            this.parent = parent;
            AvaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
            if (string.IsNullOrEmpty(project.EndDate) || string.IsNullOrWhiteSpace(project.EndDate)) {
                EndDate = "No end date";
            }
            if (project.EndDate == "No end date") {
                AvaliableStatusList.Remove("Закончен");
            }
            ShowStatusChangeControls = new Command(OnShowStatusChangeControls);
            ShowDisplayStatusControls = new Command(OnShowDisplayStatusControls);
            statusChangeMode = "Hidden";
            statusDisplayMode = "Visible";
        }

        public ICommand ShowStatusChangeControls { get; private set; }
        public ICommand ShowDisplayStatusControls { get; private set; }

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

        public string Status {
            get { return project.Status; }
            set {
                project.Status = value;
                OnPropertyChanged("Status");
            }
        }

        public List<string> AvaliableStatusList { get; }

        public string EndDate {
            get { return project.EndDate; }
            set {
                project.EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string StatusChangeMode {
            get { return statusChangeMode; }
            set {
                statusChangeMode = value;
                OnPropertyChanged("StatusChangeMode");
            }
        }

        public string StatusDisplayMode {
            get { return statusDisplayMode; }
            set {
                statusDisplayMode = value;
                OnPropertyChanged("StatusDisplayMode");
            }
        }

        public ICommand Remove {
            get { return removeCommand ?? (removeCommand = new Command(() => parent.RemoveProject(project))); }
        }

        private void OnShowStatusChangeControls() {
            StatusChangeMode = "Visible";
            StatusDisplayMode = "Hidden";
        }

        private void OnShowDisplayStatusControls() {
            StatusChangeMode = "Hidden";
            StatusDisplayMode = "Visible";
        }
    }
}