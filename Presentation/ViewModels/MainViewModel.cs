namespace Presentation.ViewModels {
    public class MainViewModel : ViewModel {
        public MainViewModel(ClientListViewModel clientListViewModel, ProjectListViewModel projectListViewModel) {
            ClientList = clientListViewModel;
            ProjectList = projectListViewModel;
        }

        public ClientListViewModel ClientList { get; }

        public ProjectListViewModel ProjectList { get; }
    }
}