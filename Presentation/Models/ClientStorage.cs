#region Usings

using System.Collections.ObjectModel;

#endregion

namespace Presentation.Models {
    public class ClientStorage {
        public ClientStorage() {
            Clients = new ObservableCollection<Client>();
        }

        public ObservableCollection<Client> Clients { get; }

        public void AddClient(Client client) {
            Clients.Add(client);
        }
    }
}