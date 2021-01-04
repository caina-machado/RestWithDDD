using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Service.Test.User
{
    public class WhenGetByIdIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Complete Get By Id")]
        public async Task IsPossibleToCompleteGetById()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.FindByIdAsync(UserId)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.FindByIdAsync(UserId);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
            Assert.Equal(UserId, result.Id);
        }
    }
}
