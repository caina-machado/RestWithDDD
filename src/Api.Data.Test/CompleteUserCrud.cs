using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Context;
using src.Api.Data.Repositories.User;
using src.Api.Domain.Entities;
using Xunit;

namespace src.Api.Data.Test
{
    public class CompleteUserCrud : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CompleteUserCrud(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "UserCrudTesting")]
        [Trait("CRUD", "UserEntity")]
        public async Task IsPossibleToCompleteUserCrud()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserRepository repository = new UserRepository(context);
                UserEntity entity = new UserEntity
                {
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };

                var insertRegister = await repository.InsertAsync(entity);
                Assert.NotNull(insertRegister);
                Assert.Equal(insertRegister.Name, entity.Name);
                Assert.Equal(insertRegister.Email, entity.Email);
                Assert.False(insertRegister.Id == Guid.Empty);
                Assert.NotNull(insertRegister.CreateAt);
                Assert.Null(insertRegister.UpdateAt);

                entity.Name = Faker.Name.First();

                var updateRegister = await repository.UpdateAsync(entity);
                Assert.NotNull(insertRegister);
                Assert.Equal(updateRegister.Name, entity.Name);
                Assert.Equal(updateRegister.Email, entity.Email);
                Assert.Equal(updateRegister.Id, entity.Id);
                Assert.Equal(updateRegister.CreateAt, entity.CreateAt);
                Assert.NotNull(insertRegister.UpdateAt);

                var foundAll = await repository.FindAllAsync();
                Assert.NotEmpty(foundAll);

                var foundById = await repository.FindByIdAsync(entity.Id);
                Assert.NotNull(foundById);

                var existsResult = await repository.ExistsAsync(entity.Id);
                Assert.True(existsResult);

                var deleteResult = await repository.DeleteAsync(entity.Id);
                Assert.True(deleteResult);

                var existsResultAfterDelete = await repository.ExistsAsync(entity.Id);
                Assert.False(existsResultAfterDelete);
            }
        }
    }
}
