using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenDeleteIsRequested
{
    public class ReturnBadRequest
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Not Possible To Request Delete")]
        public async Task IsNotPossibleToRequestDelete()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.DeleteAsync(It.IsAny<Guid>())).ReturnsAsync(false);

            controller = new UsersController(serviceMock.Object);
            controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await controller.DeleteAsync(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
