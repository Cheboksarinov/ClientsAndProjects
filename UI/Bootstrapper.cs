#region Usings

using Infrastructure;
using Presentation.Models;
using Presentation.ViewModels;

#endregion

namespace UI {
    public class Bootstrapper {
        public static void Run() {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public void Start(MainWindow window) {
            var dataManager = new DataManager();
            var clientStorage = new ClientStorage();
            var projectStorage = new ProjectStorage();
            LoadDefaultData(dataManager, clientStorage, projectStorage);
            window.DataContext = PrepareMainViewModel(clientStorage, projectStorage);
            window.Show();
        }

        private void LoadDefaultData(DataManager dataManager, ClientStorage clientStorage, ProjectStorage projectStorage) {
            dataManager.LoadDefaultClients(clientStorage);
            dataManager.LoadDefaultProjects(projectStorage);
        }

        private MainViewModel PrepareMainViewModel(ClientStorage clientStorage, ProjectStorage projectStorage) {
            var clientListViewModel = new ClientListViewModel(clientStorage);
            var projectListViewModel = new ProjectListViewModel(projectStorage);
            var mainViewModel = new MainViewModel(clientListViewModel, projectListViewModel);
            return mainViewModel;
        }
    }
}