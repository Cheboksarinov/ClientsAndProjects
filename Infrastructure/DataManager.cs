#region Usings

using System.Linq;
using Presentation;
using Presentation.Models;

#endregion

namespace Infrastructure {
    public class DataManager {
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
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Enbridge",
                Name = "iOS CDR",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "Согласование договора")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Enbridge",
                Name = "Punch List",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "Переговоры")
            });
            projectStorage.AddProject(new Project {
                ClientName = "DODO",
                Name = "Dodo IS",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Avicom",
                Name = "PJM",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "В работе")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Павел",
                Name = "Kinect",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "Переговоры")
            });
            projectStorage.AddProject(new Project {
                ClientName = "Дмитрий",
                Name = "Android-Касса",
                Status = AvaliableProjectStatus.GetAvaliableStatusList().Single(_ => _ == "Первичный контакт")
            });
        }
    }
}