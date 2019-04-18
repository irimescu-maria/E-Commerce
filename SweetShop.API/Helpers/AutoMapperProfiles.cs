using AutoMapper;
using SweetShop.API.Data;
using SweetShop.API.Dtos;
using SweetShop.API.Models;

namespace SweetShop.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
             CreateMap<UserForRegisterDto, User>();
              CreateMap<User, UserForDetailedDto>();
             
        }
       

    }
}