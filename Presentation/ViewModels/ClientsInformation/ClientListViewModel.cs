#region Usings

using System.Collections.ObjectModel;
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

        public ObservableCollection<ClientViewModel> Client {
            get {
                var clientsCollection = new ObservableCollection<ClientViewModel>();
                foreach (var client in clientStorage.Clients) {
                    clientsCollection.Add(new ClientViewModel(client, this)); 
                }
                return clientsCollection;
            }
        }

        public NewClientViewModel NewClient { get; private set; }

        private void OnShowNewClientControl() {
            NewClient.AddNewClientDialogVisible = "Visible";
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
            NewClient.AddNewClientDialogVisible = "Hidden";
            OnPropertyChanged("NewClient");
        }
    }
}