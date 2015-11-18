using System.Linq;
using NUnit.Framework;
using Presentation.Models;
using Presentation.ViewModels;

namespace UnitTests.ViewModels {
    [TestFixture]
    internal class ClientListViewModelShould {
        [SetUp]
        public void SetUp() {
            clientStorage = new ClientStorage();
        }

        private ClientListViewModel clientListViewModel;
        private ClientStorage clientStorage;

        private bool? IsClientStorageContainClient(Client clientForRemove) {
            return clientStorage.Clients.Contains(clientForRemove);
        }

        private ClientListViewModel Open() {
            return new ClientListViewModel(clientStorage);
        }

        [Test]
        public void RemoveClientFromStorageWhenClickRemoveButton() {
            var clientForRemove = new Client {Name = "Name 1", ContactName = "Contact 1"};
            clientStorage.AddClient(clientForRemove);
            clientListViewModel = Open();

            clientListViewModel.Client.Single().Remove.Execute(null);

            Assert.IsFalse(IsClientStorageContainClient(clientForRemove));
        }
    }
}