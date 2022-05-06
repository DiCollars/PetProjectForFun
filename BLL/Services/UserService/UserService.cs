using AutoMapper;
using BLL.Services.HashPasswordService;
using DAL.Models;
using DAL.Repositories.UserRepository;
using Mapper.UserDTO.BLLDTO;

namespace BLL.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository
            , IHashPasswordService hashPasswordService
            , IMapper mapper
            )
        {
            _userRepository = userRepository;
            _hashPasswordService = hashPasswordService;
            _mapper = mapper;
        }

        public async Task Create(BUserFull user)
        {
            user.Password = _hashPasswordService.HashPassword(user.Password);
            await _userRepository.Create(_mapper.Map<User>(user));
        }

        public async Task<IEnumerable<BUserFull>> GetAll(int skip, int take)
        {
            if (skip == 0 && take == 0)
            {
                take = int.MaxValue;
            }

            return (await _userRepository.GetAll(skip, take)).Select(u => _mapper.Map<BUserFull>(u));
        }
    }
}
