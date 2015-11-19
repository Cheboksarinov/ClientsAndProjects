using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels {
    public class ProjectViewModel : ViewModel {
        private readonly List<string> avaliableStatusList;
        private readonly ProjectListViewModel parent;
        private readonly Project project;
        private ICommand removeCommand;
        private Visibility statusChangeMode;
        private Visibility statusDisplayMode;

        public ProjectViewModel(Project project, ProjectListViewModel parent) {
            this.project = project;
            this.parent = parent;
            avaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
            ShowStatusChangeControls = new Command(OnShowStatusChangeControls);
            ShowDisplayStatusControls = new Command(OnShowDisplayStatusControls);
            statusChangeMode = Visibility.Hidden;
            statusDisplayMode = Visibility.Visible;
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

        public List<string> AvaliableStatusList {
            get { return avaliableStatusList; }
        }

        public Visibility StatusChangeMode {
            get { return statusChangeMode; }
            set {
                statusChangeMode = value;
                OnPropertyChanged("StatusChangeMode");
            }
        }

        public Visibility StatusDisplayMode {
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
            StatusChangeMode = Visibility.Visible;
            StatusDisplayMode = Visibility.Hidden;
        }

        private void OnShowDisplayStatusControls() {
            StatusChangeMode = Visibility.Hidden;
            StatusDisplayMode = Visibility.Visible;
        }
    }
}