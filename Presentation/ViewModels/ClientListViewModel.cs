using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels {
    public class ClientListViewModel : ViewModel {
        private readonly ClientStorage clientStorage;
        private NewClientViewModel newClient;
        public ClientListViewModel(ClientStorage clientStorage) {
            this.clientStorage = clientStorage;
            newClient = new NewClientViewModel(this);
            ShowNewClientControl = new Command(OnShowNewClientControl);
        }

        public ICommand ShowNewClientControl { get; private set; }


        public IEnumerable<ClientViewModel> Client {
            get {
                return from client in clientStorage.Clients
                    select new ClientViewModel(client, this);
            }
        }

        public NewClientViewModel NewClient {
            get { return newClient; }
        }

        internal void RemoveClient(Client client) {
            clientStorage.Clients.Remove(client);

            OnPropertyChanged("Client");
        }

        internal void AddClient(Client client) {
            clientStorage.AddClient(client);
            OnPropertyChanged("Client");
            newClient = new NewClientViewModel(this);
            HideNewClientControl();
        }

        public void OnShowNewClientControl() {
            newClient.Visible = Visibility.Visible;
            OnPropertyChanged("NewClient");
        }

        private void HideNewClientControl() {
            newClient.Visible = Visibility.Hidden;
            OnPropertyChanged("NewClient");
        }
    }
}