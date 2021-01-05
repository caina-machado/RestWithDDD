using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenDeleteIsRequested
{
    public class ReturnDelete
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Possible To Request Delete")]
        public async Task IsPossibleToRequestDelete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(true);

            controller = new UsersController(serviceMock.Object);

            var result = await controller.DeleteAsync(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
