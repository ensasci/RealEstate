using AutoMapper;
using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Advert, AllAdvertsResponseModel>();
            CreateMap<FavoriteAdvert, FavoriteAdvertsResponseModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Advert.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AdvertId, opt => opt.MapFrom(src => src.Advert.Id))
                .ForMember(dest => dest.County, opt => opt.MapFrom(src => src.Advert.County))
                .ForMember(dest => dest.Town, opt => opt.MapFrom(src => src.Advert.Town))
                .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Advert.Adress))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Advert.Price));
		}
    }
}
