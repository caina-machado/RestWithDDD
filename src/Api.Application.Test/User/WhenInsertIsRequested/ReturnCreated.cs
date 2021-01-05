using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenInsertIsRequested
{
    public class ReturnCreated
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Possible To Request Insert")]
        public async Task IsPossibleToRequestInsert()
        {
            var serviceMock = new Mock<IUserService>();

            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMock.Setup(m => m.InsertAsync(It.IsAny<CreateUserDTO>())).ReturnsAsync(
                new UserCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreateAt = DateTime.Now
                }
            );

            controller = new UsersController(serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:0000");
            controller.Url = url.Object;

            var createUserDto = new CreateUserDTO
            {
                Name = name,
                Email = email
            };

            var result = await controller.InsertAsync(createUserDto);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserCreateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(resultValue.Name, name);
            Assert.Equal(resultValue.Email, email);
            Assert.False(resultValue.Id == Guid.Empty);
        }
    }
}
