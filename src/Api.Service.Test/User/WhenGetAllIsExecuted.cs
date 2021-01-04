using System.Linq;
using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Service.Test.User
{
    public class WhenGetAllIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Complete Get All")]
        public async Task IsPossibleToCompleteGetAll()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.FindAllAsync()).ReturnsAsync(userDtoList);
            _service = _serviceMock.Object;

            var result = await _service.FindAllAsync();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.True(result.Count() == 10);
        }
    }
}
