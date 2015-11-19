using System.Windows;
using System.Windows.Input;
using Presentation.Models;

namespace Presentation.ViewModels {
    public class NewClientViewModel : ViewModel {
        private readonly Client client;
        private readonly ClientListViewModel parent;
        private ICommand addCommand;
        private Visibility visible;
        public NewClientViewModel(ClientListViewModel parent) {
            this.parent = parent;
            client = new Client {Name = "", ContactName = ""};
            visible = Visibility.Hidden;
        }
        public string ContactName {
            get { return client.ContactName; }
            set {
                client.ContactName = value;
                OnPropertyChanged("ContactName");
            }
        }
        public string Name {
            get { return client.Name; }
            set {
                client.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public Visibility Visible {
            get { return visible; }
            set {
                visible = value;
                OnPropertyChanged("Visible");
            }
        }
        public ICommand Add {
            get { return addCommand ?? (addCommand = new Command(() => parent.AddClient(client))); }
        }
    }
}