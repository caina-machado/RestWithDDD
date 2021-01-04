using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Service.Test.User
{
    public class WhenDeleteIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Complete Delete")]
        public async Task IsPossibleToCompleteDelete()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.DeleteAsync(UserId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.DeleteAsync(UserId);
            Assert.NotNull(result);
            Assert.True(result);
        }
    }
}
