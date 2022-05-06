using AutoMapper;
using DAL.Repositories.UserRepository;
using Mapper.UserDTO.BLLDTO;

namespace BLL.Services.HashPasswordService
{
    public class HashPasswordService : IHashPasswordService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public HashPasswordService(
              IUserRepository userRepository
            , IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
                return _mapper.Map<BUserFull>(user);
            }
            else
            {
                throw new Exception("Password is invalid.");
            }
        }
    }
}
