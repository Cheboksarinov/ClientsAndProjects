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

        private void InsertNewClientData(Client clientForAdd) {
            clientListViewModel.NewClient.Name = clientForAdd.Name;
            clientListViewModel.NewClient.ContactName = clientForAdd.ContactName;
        }

        private bool? IsClientStorageContainClient(Client client) {
            return clientStorage.Clients.Any(_ => _.Name == client.Name && _.ContactName == client.ContactName);
        }

        private ClientListViewModel Open() {
            return new ClientListViewModel(clientStorage);
        }

        [Test]
        public void AddClientToStorageWhenClickAddButton() {
            var clientForAdd = new Client {Name = "Name 1", ContactName = "Contact 1"};
            clientListViewModel = Open();
            InsertNewClientData(clientForAdd);

            clientListViewModel.NewClient.Add.Execute(null);

            Assert.IsTrue(IsClientStorageContainClient(clientForAdd));
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