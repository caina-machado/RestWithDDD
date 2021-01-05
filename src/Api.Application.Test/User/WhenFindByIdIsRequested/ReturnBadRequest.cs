using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenFindByIdIsRequested
{
    public class ReturnBadRequest
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Not Possible To Request FindById")]
        public async Task IsNotPossibleToRequestFindById()
        {
            var serviceMock = new Mock<IUserService>();

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.FindByIdAsync(It.IsAny<Guid>())).ReturnsAsync(
                new UserDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email
                }
            );

            controller = new UsersController(serviceMock.Object);
            controller.ModelState.AddModelError("Id", "Formato inválido");

            var result = await controller.FindByIdAsync(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
