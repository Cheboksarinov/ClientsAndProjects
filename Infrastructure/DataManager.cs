using Presentation.Models;

namespace Infrastructure {
    public class DataManager {
        public void LoadDefaultClients(ClientStorage clientStorage) {
            clientStorage.AddClient(new Client {Name = "Enbridge", ContactName = "Daren"});
            clientStorage.AddClient(new Client {Name = "DODO", ContactName = "Фёдор"});
            clientStorage.AddClient(new Client {Name = "Avicom", ContactName = "Евгений"});
            clientStorage.AddClient(new Client {Name = "Павел", ContactName = "Павел"});
            clientStorage.AddClient(new Client {Name = "Дмитрий", ContactName = "Дмитрий"});
        }
    }
}