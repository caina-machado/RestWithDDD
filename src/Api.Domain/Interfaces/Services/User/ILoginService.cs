using System.Threading.Tasks;
using src.Api.Domain.DTOs;

namespace src.Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDTO user);
    }
}
