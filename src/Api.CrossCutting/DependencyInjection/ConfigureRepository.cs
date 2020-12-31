using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src.Api.Data.Context;
using src.Api.Data.Repositories;
using src.Api.Data.Repositories.User;
using src.Api.Domain.Interfaces;
using src.Api.Domain.Interfaces.Repositories;

namespace src.Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependeciesRepository(IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddDbContext<MyContext>(options =>
                options.UseMySql("Server=localhost;Port=3306;Database=ddd_api_db;Uid=developer;Pwd=7654321")
            );
        }
    }
}
