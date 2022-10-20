using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Moq;
using TimeLogger.AppService.Contract.Logs;
using TimeLogger.AppService.Contract.Projects;
using TimeLogger.AppService.Logs;
using TimeLogger.AppService.Projects;
using TimeLogger.DomainService.Logs;
using TimeLogger.DomainService.Projects;
using TimeLogger.Model.Logs;
using TimeLogger.Model.Projects;
using Xunit;

namespace Appservice.Test.Logs
{
    public class LogServiceTest
    {
        private readonly ILogService _service;

        public LogServiceTest()
        {
            _service = new LogService(GetDomain());
        }

      
        [Fact]
        public async Task Add_CheckInvalidLogDescription_ValidationException()
        {
            var log = new LogView
            {
                Description = 
                    "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890" +
                    "78901234567890123456789012345678901234567890123456789012345678901234567890"
            };
            var action = new Func<Task<LogView>>(() => _service.Add(log));

            await action.Should()
                .ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Add_CheckValidLogDescription_NoException()
        {
            var log = new LogView
            {
                Description = "01234567890"
            };
            var action = new Func<Task<LogView>>(() => _service.Add(log));

            await action.Should()
                .NotThrowAsync();
        }
        private ILogDomain GetDomain()
        {
            var domainMock = new Mock<ILogDomain>();
            domainMock.Setup(e => e.Add(It.IsAny<LogModel>()));

            return domainMock.Object;
        }


    }
}
//Todo
//add test for all of it