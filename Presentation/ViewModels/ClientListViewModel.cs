using System.Collections.Generic;
using System.Linq;
using Presentation.Models;

namespace Presentation.ViewModels {
    public class ClientListViewModel : ViewModel {
        private readonly ClientStorage clientStorage;

        public ClientListViewModel(ClientStorage clientStorage) {
            this.clientStorage = clientStorage;
        }
        public IEnumerable<ClientViewModel> Client {
            get {
                return from client in clientStorage.Clients
                    select new ClientViewModel(client, this);
            }
        }
        internal void RemoveClient(Client client) {
            clientStorage.Clients.Remove(client);

            OnPropertyChanged("Client");
        }
    }
}