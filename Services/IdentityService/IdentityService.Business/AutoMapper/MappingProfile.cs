using AutoMapper;
using CorePackage.Entities.Concrete;
using IdentityService.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IdentityService.Entities.DTO.UserDTO;

namespace IdentityService.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<LoginDTO, User>().ReverseMap();
            CreateMap<RegisterDTO, User>().ReverseMap();
            CreateMap<UserByEmailDTO, User>().ReverseMap();
        } 
    }
}
