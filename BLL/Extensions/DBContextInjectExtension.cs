using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class DBContextInjectExtension
    {
        public static IServiceCollection AddAppDBContext(this IServiceCollection serviceCollection,
        string connectionString)
        {
            serviceCollection.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));
            return serviceCollection;
        }
    }
}
