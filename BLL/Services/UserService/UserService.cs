using BLL.DTO;
using BLL.Services.HashPasswordService;
using DAL.Models;
using DAL.Repositories.UserRepository;

namespace BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IHashPasswordService hashPasswordService)
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
        }

        public async Task Create(BUserFull user)
        {
            user.Password = _hashPasswordService.HashPassword(user.Password);
            await _userRepository.Create(new User 
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role,
                Password = user.Password,
                ProfileName = user.ProfileName
            });
        }

        public async Task<IEnumerable<BUserFull>> GetAll(int skip, int take)
        {
            //TODO: Add mapper for DTO
            if (skip == 0 && take == 0)
            {
                take = int.MaxValue;
            }

            return (await _userRepository.GetAll(skip, take)).Select(u => new BUserFull 
            {
                Id = u.Id, 
                Login = u.Login, 
                Password = u.Password,
                Role = u.Role       
            });
        }
    }
}
