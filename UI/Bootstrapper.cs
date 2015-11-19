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
            var dataManager = new DataManager();
            dataManager.LoadDefaultClients(clientStorage);
            var clientListViewModel = new ClientListViewModel(clientStorage);
            var mainViewModel = new MainViewModel(clientListViewModel);
            window.DataContext = mainViewModel;
            window.Show();
        }
    }
}