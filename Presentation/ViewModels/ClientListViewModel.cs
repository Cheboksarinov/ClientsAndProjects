using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Models;

namespace Presentation.ViewModels
{
    public class ClientListViewModel:ViewModel
    {
        private readonly ClientStorage clientStorage;

        public ClientListViewModel(ClientStorage clientStorage)
        {
            this.clientStorage = clientStorage;
        }

        public IEnumerable<ClientViewModel> Client
        {
            get
            {
                return from client in clientStorage.Clients
                       select new ClientViewModel(client, this);
            }
        }

    
    }
}
