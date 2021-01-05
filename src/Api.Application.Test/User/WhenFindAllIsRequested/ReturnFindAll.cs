using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using src.Api.Application.Controllers;
using src.Api.Domain.DTOs.User;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Application.Test.User.WhenFindAllIsRequested
{
    public class ReturnFindAll
    {
        private UsersController controller;

        [Fact(DisplayName = "Is Possible To Request FindAll")]
        public async Task IsPossibleToRequestFindAll()
        {
            var serviceMock = new Mock<IUserService>();

            serviceMock.Setup(m => m.FindAllAsync()).ReturnsAsync(
                new List<UserDTO>
                {
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email()
                    },
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Name.FullName(),
                        Email = Faker.Internet.Email()
                    }
                }
            );

            controller = new UsersController(serviceMock.Object);

            var result = await controller.FindAllAsync();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDTO>;
            Assert.NotEmpty(resultValue);
            Assert.True(resultValue.Count() == 2);
        }
    }
}
