using BLL.DTO;

namespace BLL.Services.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<BUserFull>> GetAll(int skip = 0, int take = int.MaxValue);

        Task Create(BUserFull item);
    }
}
