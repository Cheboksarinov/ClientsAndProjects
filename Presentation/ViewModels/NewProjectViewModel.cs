using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels
{
    public class NewProjectViewModel:ViewModel
    {
        private readonly Project project;
        private readonly ProjectListViewModel parent;
        private readonly List<string> avaliableStatusList;
        private Visibility visible;
        private ICommand addCommand;

        public NewProjectViewModel(ProjectListViewModel parent) {
            this.parent = parent;
            project = new Project{ClientName = "", Name = "",Status = ""};
            avaliableStatusList = AvaliableProjectStatus.GetAvaliableStatusList();
            visible = Visibility.Hidden;
            Status = avaliableStatusList.First();
        }

        public string Name
        {
            get { return project.Name; }
            set
            {
                project.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<string> AvaliableStatusList {
            get { return avaliableStatusList; }
        }

        public string ClientName
        {
            get { return project.ClientName; }
            set
            {
                project.ClientName = value;
                OnPropertyChanged("ClientName");
            }
        }
        public string Status
        {
            get { return project.Status; }
            set
            {
                project.Status = value;
                OnPropertyChanged("Status");
            }
        }
        public Visibility Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }
        public ICommand Add
        {
            get { return addCommand ?? (addCommand = new Command(() => parent.AddProject(project))); }
        }
    }
}
