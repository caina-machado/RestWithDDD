using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using src.Api.Domain.DTOs.User;
using Xunit;

namespace src.Api.Integration.Test.User
{
    public class WhenUserIsRequested : BaseIntegration
    {
        private string _name { get; set; }
        private string _email { get; set; }

        [Fact(DisplayName = "Is Possible To Complete User Crud")]
        public async Task IsPossibleToCompleteUserCrud()
        {
            await AddToken();
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new CreateUserDTO
            {
                Name = _name,
                Email = _email
            };

            var response = await PostJsonAsync(userDto, $"{HostApi}/users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postRegister = JsonConvert.DeserializeObject<UserCreateResultDTO>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, postRegister.Name);
            Assert.Equal(_email, postRegister.Email);
            Assert.False(postRegister.Id == Guid.NewGuid());

            response = await Client.GetAsync($"{HostApi}/users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getAllResult = await response.Content.ReadAsStringAsync();
            var getAllRegister = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(getAllResult);
            Assert.NotEmpty(getAllRegister);
            Assert.NotNull(getAllRegister);
            Assert.True(getAllRegister.Count() > 0);
            Assert.True(getAllRegister.Where(r => r.Id == postRegister.Id).Count() == 1);

            var userUpdateDto = new UpdateUserDTO
            {
                Id = postRegister.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(userUpdateDto), Encoding.UTF8, "application/json");

            response = await Client.PutAsync($"{HostApi}/users", stringContent);
            var putResult = await response.Content.ReadAsStringAsync();
            var putRegister = JsonConvert.DeserializeObject<UserUpdateResultDTO>(putResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(postRegister.Name, putRegister.Name);
            Assert.NotEqual(postRegister.Email, putRegister.Email);
            Assert.Equal(postRegister.Id, putRegister.Id);

            response = await Client.GetAsync($"{HostApi}/users/{postRegister.Id}");
            var getByIdResult = await response.Content.ReadAsStringAsync();
            var getByIdRegister = JsonConvert.DeserializeObject<UserDTO>(getByIdResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(getByIdRegister);
            Assert.Equal(putRegister.Name, getByIdRegister.Name);
            Assert.Equal(putRegister.Email, getByIdRegister.Email);

            response = await Client.DeleteAsync($"{HostApi}/users/{postRegister.Id}");
            var deleteResult = await response.Content.ReadAsStringAsync();
            var deleteRegister = JsonConvert.DeserializeObject<bool>(deleteResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(deleteRegister);

            response = await Client.GetAsync($"{HostApi}/users/{postRegister.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
