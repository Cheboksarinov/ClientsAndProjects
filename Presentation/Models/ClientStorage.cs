using System.Collections.Generic;

namespace Presentation.Models {
    public class ClientStorage {
        public ClientStorage() {
            Clients = new List<Client>();
        }

        public ICollection<Client> Clients { get; private set; }

        public void AddClient(Client client) {
            Clients.Add(client);
        }
    }
}