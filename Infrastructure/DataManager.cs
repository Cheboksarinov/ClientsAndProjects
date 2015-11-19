using System.Collections.Generic;
using System.Linq;
using Presentation.Models;

namespace Infrastructure {
    public class DataManager {
        private readonly List<string> projectStatusCollection;

        public DataManager() {
            projectStatusCollection = new List<string> {
                "Первичный контакт",
                "Переговоры",
                "Согласование договора",
                "В работе",
                "Закончен"
            };
        }

        public void LoadDefaultClients(ClientStorage clientStorage) {
            clientStorage.AddClient(new Client {Name = "Enbridge", ContactName = "Daren"});
            clientStorage.AddClient(new Client {Name = "DODO", ContactName = "Фёдор"});
            clientStorage.AddClient(new Client {Name = "Avicom", ContactName = "Евгений"});
            clientStorage.AddClient(new Client {Name = "Павел", ContactName = "Павел"});
            clientStorage.AddClient(new Client {Name = "Дмитрий", ContactName = "Дмитрий"});
        }

        public void LoadDefaultProjects(ProjectStorage projectStorage) {
            projectStorage.AddProject(new Project {
                ClientName = "Enbridge",
                Name = "iOS QDR",
                Status = projectStatusCollection.Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Enbridge",
                Name = "iOS CDR",
                Status = projectStatusCollection.Single(_ => _ == "Согласование договора")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Enbridge",
                Name = "Punch List",
                Status = projectStatusCollection.Single(_ => _ == "Переговоры")
            });
            projectStorage.AddProject(new Project {
                ClientName = "DODO",
                Name = "Dodo IS",
                Status = projectStatusCollection.Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Avicom",
                Name = "PJM",
                Status = projectStatusCollection.Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Павел",
                Name = "Kinect",
                Status = projectStatusCollection.Single(_ => _ == "Переговоры")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Дмитрий",
                Name = "Android-Касса",
                Status = projectStatusCollection.Single(_ => _ == "Первичный контакт")
            });
        }
    }
}