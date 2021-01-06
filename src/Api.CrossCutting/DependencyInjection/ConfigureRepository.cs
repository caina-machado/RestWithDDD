using System;
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

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
            {
                service.AddDbContext<MyContext>(options =>
                    options.UseMySql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}
