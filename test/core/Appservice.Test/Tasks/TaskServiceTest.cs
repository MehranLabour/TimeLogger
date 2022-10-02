using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Moq;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Contract.Tasks;
using TimeLogger.AppService.Tasks;
using TimeLogger.DomainService.Tasks;
using TimeLogger.Model.Tasks;
using Xunit;

namespace Appservice.Test.Tasks
{
    public class TaskServiceTest
    {
        private ITaskService _service;

        public TaskServiceTest()
        {
            _service = new TaskService(GetDomain());
        }

        [Fact]

        public async Task Add_CheckInvalidTaskName_ValidationException()
        {
            var task = new TaskView
            {
                Name =
                    "amsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlkamsddfljjksflkjljksdfjlk"
            };
            var action = new Func<Task<TaskView>>(() => _service.Add(task));
           await action.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Add_CheckValidTaskName_ValidationException()
        {
            var task = new TaskView
            {
                Name =
                    "jhgjhgjhgjhjhjk"
            };
            var action = new Func<Task<TaskView>>(() => _service.Add(task));

            await action.Should()
                .NotThrowAsync();
        }


        private ITaskDomain GetDomain()
        {
            var domainMock = new Mock<ITaskDomain>();
            domainMock.Setup(e => e.Add(It.IsAny<TaskModel>()));
            return domainMock.Object;
        }
    }
}
