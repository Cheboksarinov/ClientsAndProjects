#region Usings

using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

#endregion

namespace Presentation.ViewModels.ClientsInformation {
    public class ClientListViewModel : ViewModel {
        private readonly ClientStorage clientStorage;

        public ClientListViewModel(ClientStorage clientStorage) {
            this.clientStorage = clientStorage;
            NewClient = new NewClientViewModel(this);
            ShowNewClientControl = new Command(OnShowNewClientControl);
        }

        public ICommand ShowNewClientControl { get; private set; }

        public IEnumerable<ClientViewModel> Client {
            get {
                return from client in clientStorage.Clients
                    select new ClientViewModel(client, this);
            }
        }

        public NewClientViewModel NewClient { get; private set; }

        private void OnShowNewClientControl() {
            NewClient.AddNewClientDialogVisible = Visibility.Visible;
            OnPropertyChanged("NewClient");
        }

        internal void RemoveClient(Client client) {
            clientStorage.Clients.Remove(client);

            OnPropertyChanged("Client");
        }

        internal void AddClient(Client client) {
            clientStorage.AddClient(client);
            OnPropertyChanged("Client");
            NewClient = new NewClientViewModel(this);
            HideNewClientControl();
        }

        private void HideNewClientControl() {
            NewClient.AddNewClientDialogVisible = Visibility.Hidden;
            OnPropertyChanged("NewClient");
        }
    }
}