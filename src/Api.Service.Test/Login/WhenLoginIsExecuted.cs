using System;
using System.Threading.Tasks;
using Moq;
using src.Api.Domain.DTOs;
using src.Api.Domain.Interfaces.Services.User;
using Xunit;

namespace src.Api.Service.Test.Login
{
    public class WhenLoginIsExecuted
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Login")]
        public async Task IsPossibleToLogin()
        {
            string email = Faker.Internet.Email();

            var returnObject = new
            {
                authenticated = true,
                created = DateTime.Now,
                expiration = DateTime.Now.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Successful login"
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(returnObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}
