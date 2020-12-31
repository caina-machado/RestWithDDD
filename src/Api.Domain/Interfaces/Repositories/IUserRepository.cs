using System.Threading.Tasks;
using src.Api.Domain.Entities;

namespace src.Api.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin(string email);
    }
}
