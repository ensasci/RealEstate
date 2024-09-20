using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts
{
	public class FavoriteAdvertsService : IFavoriteAdvertService
	{
		private readonly IRepository<FavoriteAdvert> _favoriteAdvertRepository;
		private readonly IMapper _mapper;
		public FavoriteAdvertsService(IRepository<FavoriteAdvert> favoriteAdvertRepository, IMapper mapper)
		{
			_favoriteAdvertRepository = favoriteAdvertRepository;
			_mapper = mapper;
		}
		public async Task<bool> AddToFavorite(AddToFavoriteRequestModel request)
		{
			var isExist = await IsThereFavorite(request.AdvertId,request.UserId);
			if (isExist==false)
			{
				await _favoriteAdvertRepository.Create(new FavoriteAdvert
				{
					UserId = request.UserId,
					AdvertId = request.AdvertId,
				});
				return true;
			}
			return false;

		}

		public List<FavoriteAdvertsResponseModel> GetFavoriteAdverts(int id)
		{
			var adverts = _favoriteAdvertRepository.GetAllInclude(x => x.UserId == id && x.Advert.IsDeleted == false,x=> x.User, x=> x.Advert);
			return _mapper.Map<List<FavoriteAdvertsResponseModel>>(adverts);
		}

		public async Task<bool> IsThereFavorite(int advertId, int userId)
		{
			var advert = _favoriteAdvertRepository.GetAll(x=> x.UserId==userId && x.AdvertId==advertId).FirstOrDefault();
			if (advert!=null)
			{
				return true;
			}
			return false;
		}

		public async Task<bool> RemoveFromFavorite(int id)
		{
			var result =await _favoriteAdvertRepository.Delete(id);
			return result;
		}
	}
}
