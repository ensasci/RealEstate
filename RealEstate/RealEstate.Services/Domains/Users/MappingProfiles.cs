using AutoMapper;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Users
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, LoginResponseModel>();
            CreateMap<User, RegisterResponseModel>();
            CreateMap<User, GetUserReponseModel>();
            CreateMap<User, UserListItemModel>();
            CreateMap<User, UserModel>();
        }
    }
}
