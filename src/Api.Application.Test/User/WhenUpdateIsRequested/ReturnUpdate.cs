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
    public class ReturnUpdate
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

            var updateUserDto = new UpdateUserDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await controller.UpdateAsync(updateUserDto);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserUpdateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.Email, email);
            Assert.False(resultValue.Id == Guid.Empty);
        }
    }
}
