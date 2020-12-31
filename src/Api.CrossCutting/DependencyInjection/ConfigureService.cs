using Microsoft.Extensions.DependencyInjection;
using src.Api.Domain.Interfaces.Services;
using src.Api.Domain.Interfaces.Services.User;
using src.Api.Service.Services.User;

namespace src.Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependeciesService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoginService, LoginService>();
        }
    }
}
