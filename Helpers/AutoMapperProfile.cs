using AutoMapper;
using HospitalManagementAPI.Models;

namespace HospitalManagementAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<userLogin, UserModel>();
            CreateMap<RegisterModel, userLogin>();
            CreateMap<UpdateUser, userLogin>();
        }
    }
}