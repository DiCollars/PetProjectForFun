using DAL.Repositories.UserRepository;
using Mapper.BLLDTO;

namespace BLL.Services.HashPasswordService
{
    public class HashPasswordService : IHashPasswordService
    {
        private readonly IUserRepository _userRepository;

        public HashPasswordService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public async Task<BUserFull> Logging(string userName, string userPassword)
        {
            var user = await _userRepository.GetUserByName(userName);

            if (user == null)
            {
                throw new Exception("User isnt exist.");
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(userPassword, user.Password);

            if (isValidPassword && user != null)
            {
                return new BUserFull {  Id = user.Id, Login = user.Login, Password = user.Password, Role = user.Role };
            }
            else
            {
                throw new Exception("Password is invalid.");
            }
        }
    }
}
