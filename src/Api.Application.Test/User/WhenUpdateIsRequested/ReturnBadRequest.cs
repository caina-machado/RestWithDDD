using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenUpdateIsRequested
{
    public class ReturnBadRequest
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Possible To Request Update")]
        public async Task IsPossibleToRequestUpdate()
        {
            var serviceMock = new Mock<IUserService>();

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.UpdateAsync(It.IsAny<UpdateUserDTO>())).ReturnsAsync(
                new UserUpdateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdateAt = DateTime.Now
                }
            );

            controller = new UsersController(serviceMock.Object);
            controller.ModelState.AddModelError("Email", "É um campo obrigatório");

            var updateUserDto = new UpdateUserDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await controller.UpdateAsync(updateUserDto);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
