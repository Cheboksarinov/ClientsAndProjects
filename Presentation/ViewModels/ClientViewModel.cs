using Presentation.Models;

namespace Presentation.ViewModels
{
    public class ClientViewModel : ViewModel
    {
        private readonly Client client;
        private readonly ClientListViewModel parent;
       

        public ClientViewModel(Client client, ClientListViewModel parent)
        {
            this.client = client;
            this.parent = parent;
        }
        public string ContactName
        {
            get { return client.ContactName; }
            set
            {
                client.ContactName = value;
                OnPropertyChanged("ContactName");
            }
        }

        public string Name
        {
            get { return client.Name; }
            set
            {
                client.Name = value;
                OnPropertyChanged("Name");
            }
        }

      
    }
}
