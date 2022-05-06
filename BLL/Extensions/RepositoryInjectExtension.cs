using DAL.Repositories.UserRepository;
using DAL.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class RepositoryInjectExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            return serviceCollection;
        }
    }
}
