#region Usings

using System.Linq;
using NUnit.Framework;
using Presentation.Models;
using Presentation.ViewModels;
using Presentation.ViewModels.ProjectsInformation;

#endregion

namespace UnitTests.ViewModels {
    [TestFixture]
    internal class ProjectListViewModelShould {
        [SetUp]
        public void SetUp() {
            projectStorage = new ProjectStorage();
        }

        [Test]
        public void AddClientToStorageWhenClickAddButton() {
            var projectForAdd = new Project {
                Name = "Name 1",
                ClientName = "Client 1",
                Status = "Status 1"
            };
            projectListViewModel = Open();
            InsertNewClientData(projectForAdd);

            projectListViewModel.NewProject.Add.Execute(null);

            Assert.IsTrue(IsProjectStorageContainProject(projectForAdd));
        }

        [Test]
        public void RemoveProjectFromStorageWhenClickRemoveButton() {
            var projectForRemove = new Project {
                Name = "Name 1",
                ClientName = "Client 1",
                Status = "Status 1"
            };
            projectStorage.AddProject(projectForRemove);
            projectListViewModel = Open();

            projectListViewModel.Projects.Single().Remove.Execute(null);

            Assert.IsFalse(IsProjectStorageContainProject(projectForRemove));
        }

        private ProjectListViewModel projectListViewModel;
        private ProjectStorage projectStorage;

        private ProjectListViewModel Open() {
            return new ProjectListViewModel(projectStorage);
        }

        private bool? IsProjectStorageContainProject(Project project) {
            return projectStorage.Projects.Any(_ => _.Name == project.Name && _.ClientName == project.ClientName &&
                                                    _.Status == project.Status);
        }

        private void InsertNewClientData(Project projectForAdd) {
            projectListViewModel.NewProject.Name = projectForAdd.Name;
            projectListViewModel.NewProject.ClientName = projectForAdd.ClientName;
            projectListViewModel.NewProject.Status = projectForAdd.Status;
        }
    }
}