using AutoMapper;
using BaseASP.API.Dto.AuthDto;
using BaseASP.Model.Entities;

namespace BaseASP.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, SignUpDto>().ReverseMap();
        }
    }
}
