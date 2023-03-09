using AutoMapper;
using Domian.DTOs.User;
using Domian.Users;

namespace Authentication.ProFiles
{
    public class MappingRoFile : Profile
    {
        public MappingRoFile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
