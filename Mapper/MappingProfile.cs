using AutoMapper;
using DAL.Models;
using Mapper.UserDTO.BLLDTO;
using Mapper.UserDTO.PALDTO;

namespace Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PUserFull, BUserFull>()
                .ForMember("Id", op => op.MapFrom(c => c.Id))
                .ForMember("Login", op => op.MapFrom(c => c.Login))
                .ForMember("Password", op => op.MapFrom(c => c.Password))
                .ForMember("Role", op => op.MapFrom(c => c.Role))
                .ForMember("ProfileName", op => op.MapFrom(c => c.ProfileName))
                .ForMember("ProfilePhotoPath", op => op.MapFrom(c => c.ProfilePhotoPath))
                .ForMember("EmailAddress", op => op.MapFrom(c => c.EmailAddress))
                .ForMember("IsPrivate", op => op.MapFrom(c => c.IsPrivate));

            CreateMap<BUserFull, User>()
                .ForMember("Id", op => op.MapFrom(c => c.Id))
                .ForMember("Login", op => op.MapFrom(c => c.Login))
                .ForMember("Password", op => op.MapFrom(c => c.Password))
                .ForMember("Role", op => op.MapFrom(c => c.Role))
                .ForMember("ProfileName", op => op.MapFrom(c => c.ProfileName))
                .ForMember("ProfilePhotoPath", op => op.MapFrom(c => c.ProfilePhotoPath))
                .ForMember("EmailAddress", op => op.MapFrom(c => c.EmailAddress))
                .ForMember("IsPrivate", op => op.MapFrom(c => c.IsPrivate));

            CreateMap<BUserFull, PUserWithoutPassword > ()
                .ForMember("Id", op => op.MapFrom(c => c.Id))
                .ForMember("Login", op => op.MapFrom(c => c.Login))
                .ForMember("Role", op => op.MapFrom(c => c.Role));

            CreateMap<User, BUserFull > ()
                .ForMember("Id", op => op.MapFrom(c => c.Id))
                .ForMember("Login", op => op.MapFrom(c => c.Login))
                .ForMember("Password", op => op.MapFrom(c => c.Password))
                .ForMember("Role", op => op.MapFrom(c => c.Role))
                .ForMember("ProfileName", op => op.MapFrom(c => c.ProfileName))
                .ForMember("ProfilePhotoPath", op => op.MapFrom(c => c.ProfilePhotoPath))
                .ForMember("EmailAddress", op => op.MapFrom(c => c.EmailAddress))
                .ForMember("IsPrivate", op => op.MapFrom(c => c.IsPrivate));
        }
    }
}
