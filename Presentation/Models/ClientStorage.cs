#region Usings

using System.Collections.Generic;

#endregion

namespace Presentation.Models {
    public class ClientStorage {
        public ClientStorage() {
            Clients = new List<Client>();
        }

        public ICollection<Client> Clients { get; }

        public void AddClient(Client client) {
            Clients.Add(client);
        }
    }
}