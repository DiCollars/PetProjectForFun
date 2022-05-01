using DAL.Models;
using DAL.Repository;

namespace DAL.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByName(string login);
    }
}
