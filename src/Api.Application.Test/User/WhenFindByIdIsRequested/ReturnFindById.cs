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
    public class ReturnFindById
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Possible To Request FindById")]
        public async Task IsPossibleToRequestFindById()
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

            var result = await controller.FindByIdAsync(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(email, resultValue.Email);
            Assert.False(resultValue.Id == Guid.Empty);
        }
    }
}
