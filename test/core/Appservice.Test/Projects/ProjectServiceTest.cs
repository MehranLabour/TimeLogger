using System;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Moq;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Projects;
using TimeLogger.DomainService.Projects;
using TimeLogger.Model.Projects;
using Xunit;

namespace Appservice.Test.Projects
{
    public class ProjectServiceTest
    {
        private readonly IProjectService _service;

        public ProjectServiceTest()
        {
            _service = new ProjectService(GetDomain());
        }

        [Fact]
        public async Task Add_CheckInvalidProjectName_ValidationException()
        {
            var project = new ProjectView
            {
                Name =
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };
            var action = new Func<Task<ProjectView>>(() => _service.Add(project));

            await action.Should()
                .ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Add_CheckValidProjectName_NoException()
        {
            var project = new ProjectView
            {
                Name = "01234567890"
            };
            var action = new Func<Task<ProjectView>>(() => _service.Add(project));

            await action.Should()
                .NotThrowAsync();
        }

        private IProjectDomain GetDomain()
        {
            var domainMock = new Mock<IProjectDomain>();
            domainMock.Setup(e => e.Add(It.IsAny<ProjectModel>()));

            return domainMock.Object;
        }
    }
}