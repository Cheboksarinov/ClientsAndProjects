using Infrastructure;
using Presentation.Models;
using Presentation.ViewModels;
using UI.Controls;

namespace UI {
    public class Bootstrapper {
        public static void Run() {
            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public void Start(MainWindow window) {
            var clientStorage = new ClientStorage();
            var projectStorage = new ProjectStorage();
            var dataManager = new DataManager();
            dataManager.LoadDefaultClients(clientStorage);
            dataManager.LoadDefaultProjects(projectStorage);
            var clientListViewModel = new ClientListViewModel(clientStorage);
            var projectListViewModel = new ProjectListViewModel(projectStorage);
            var mainViewModel = new MainViewModel(clientListViewModel, projectListViewModel);
            window.DataContext = mainViewModel;
            window.Show();
        }
    }
}