using System.Linq;
using NUnit.Framework;
using Presentation.Models;
using Presentation.ViewModels;

namespace UnitTests.ViewModels {
    [TestFixture]
    internal class ProjectListViewModelShould {
        private ProjectListViewModel projectListViewModel;
        private ProjectStorage projectStorage;

        [SetUp]
        public void SetUp()
        {
            projectStorage = new ProjectStorage();
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

        private ProjectListViewModel Open()
        {
            return new ProjectListViewModel(projectStorage);
        }
        private bool? IsProjectStorageContainProject(Project project)
        {
            return projectStorage.Projects.Any(_ => _.Name == project.Name && _.ClientName == project.ClientName &&
                                                    _.Status == project.Status);
        }
    }
}