using System;
using System.Threading.Tasks;
using Moq;
using src.Api.Domain.Interfaces.Services;
using Xunit;

namespace src.Api.Service.Test.User
{
    public class WhenInsertIsExecuted : UserTests
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Is Possible To Complete Insert")]
        public async Task IsPossibleToCompleteInsert()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.InsertAsync(createUserDto)).ReturnsAsync(userCreateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.InsertAsync(createUserDto);
            Assert.NotNull(result);
            Assert.Equal(result.Name, UserName);
            Assert.Equal(result.Email, UserEmail);
            Assert.False(result.Id == Guid.Empty);
            Assert.NotNull(result.CreateAt);
        }
    }
}
