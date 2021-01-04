using System;
using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Service.Test.User
{
    public class WhenUpdateIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Complete Update")]
        public async Task IsPossibleToCompleteUpdate()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.UpdateAsync(updateUserDTO)).ReturnsAsync(userUpdateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.UpdateAsync(updateUserDTO);
            Assert.NotNull(result);
            Assert.Equal(result.Name, UserNameChanged);
            Assert.Equal(result.Email, UserEmailChanged);
            Assert.Equal(result.Id, updateUserDTO.Id);
        }
    }
}
