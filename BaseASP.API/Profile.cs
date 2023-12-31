using AutoMapper;
using BaseASP.API.AuthController.AuthVM;
using BaseASP.Model.Entities;

namespace BaseASP.API
{
    public class ProfileX : Profile
    {
        public ProfileX()
        {
            CreateMap<SignUpDto, User>();
        }

    }
}
