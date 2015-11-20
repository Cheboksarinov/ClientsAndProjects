#region Usings

using System.Windows;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ClientsInformation {
    public class NewClientViewModel : ViewModel {
        private readonly Client client;
        private readonly ClientListViewModel parent;
        private ICommand addCommand;
        private Visibility addNewClientDialogVisible;

        public NewClientViewModel(ClientListViewModel parent) {
            this.parent = parent;
            client = new Client {Name = "", ContactName = ""};
            addNewClientDialogVisible = Visibility.Hidden;
        }

        public string ContactName {
            get { return client.ContactName; }
            set {
                client.ContactName = value;
                OnPropertyChanged("ContactName");
            }
        }

        public string Name {
            get { return client.Name; }
            set {
                client.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public Visibility AddNewClientDialogVisible {
            get { return addNewClientDialogVisible; }
            set {
                addNewClientDialogVisible = value;
                OnPropertyChanged("AddNewClientDialogVisible");
            }
        }

        public ICommand Add {
            get { return addCommand ?? (addCommand = new Command(() => parent.AddClient(client))); }
        }
    }
}