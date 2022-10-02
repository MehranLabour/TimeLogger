using System;
using System.Threading.Tasks;
using Moq;
using TimeLogger.DomainService.Projects;
using TimeLogger.Model.Projects;
using Xunit;

namespace DomainService.Test
{
    public class ProjectDomainTest
    {
        private readonly IProjectDomain _domain;
        private readonly DbMock _db;
        public ProjectDomainTest()
        {
            _db = new DbMock();
            var repository = ConfigRepository();
            _domain = new ProjectDomain(repository);
        }

        private IProjectRepository ConfigRepository()
        {
            var repositoryMock = new Mock<IProjectRepository>();
            repositoryMock.Setup(e => e.Add(It.IsAny<ProjectModel>()))
                .Returns<ProjectModel>(project =>
                {
                    project.Id = _db.Projects.Count + 1;
                    _db.Projects.Add(project);
                    return Task.FromResult(project);
                });
            return repositoryMock.Object;
        }

        [Fact]
        public async Task Add_CheckProjectAdd_DbCountMustBe1()
        {
            var project = new ProjectModel
            {
                Name = "fakeName",
                PricePerHour = 1
            };
            await _domain.Add(project);
            Assert.Single(_db.Projects);
        }
    }
}