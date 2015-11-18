namespace Presentation.ViewModels {
    public class MainViewModel : ViewModel {
        private readonly ClientListViewModel clientListViewModel;

        public MainViewModel(ClientListViewModel clientListViewModel) {
            this.clientListViewModel = clientListViewModel;
        }
        public ClientListViewModel ClientList {
            get { return clientListViewModel; }
        }
    }
}