using BLL.Services.HashPasswordService;
using BLL.Services.TokenService;
using BLL.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class ServiceInjectExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IHashPasswordService, HashPasswordService>();
            serviceCollection.AddTransient<ITokenService, TokenService>();

            return serviceCollection;
        }
    }
}
