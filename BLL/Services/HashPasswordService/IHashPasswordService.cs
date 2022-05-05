using Mapper.BLLDTO;

namespace BLL.Services.HashPasswordService
{
    public interface IHashPasswordService
    {
        string HashPassword(string password);

        Task<BUserFull> Logging(string userName, string userPassword);
    }
}
