namespace Presentation.ViewModels {
    public class MainViewModel : ViewModel {
        private readonly ClientListViewModel clientListViewModel;
        private readonly ProjectListViewModel projectListViewModel;

        public MainViewModel(ClientListViewModel clientListViewModel, ProjectListViewModel projectListViewModel) {
            this.clientListViewModel = clientListViewModel;
            this.projectListViewModel = projectListViewModel;
        }
        public ClientListViewModel ClientList {
            get { return clientListViewModel; }
        }

        public ProjectListViewModel ProjectList {
            get { return projectListViewModel; }
        }
    }
}