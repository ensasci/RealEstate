using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts
{
	public class AdvertService : IAdvertService
	{
		private readonly IRepository<Advert> _advertRepository;
		private readonly IMapper _mapper;
		public AdvertService(IRepository<Advert> advertRepository, IMapper mapper)
		{
			_advertRepository = advertRepository;
			_mapper = mapper;
		}
		public async Task<bool> Add(AddAdvertRequestModel request)
		{
		var result=	await _advertRepository.Create(new Advert
			{
				UserId = request.UserId,
				Title = request.Title,
				Adress = request.Adress,
				Rooms = request.Rooms,
				Town = request.Town,
				Mahalle = request.Mahalle,
				Price = request.Price,
				Floor = request.Floor,
				Description = request.Description,
				ApproveStatus = ApproveStatus.Pending,
				Area = request.Area,
				County = request.County,
				ModifiedDate = request.ModifiedDate,
				CreatedDate = request.CreatedDate,
			});
			return result;
		}

		public List<AllAdvertsResponseModel> GetAdminAdverts()
		{
			return _mapper.Map<List<AllAdvertsResponseModel>>(_advertRepository.GetAllSingleInclude(x=> x.User));
		}

		public async Task<AllAdvertsResponseModel> GetAdvert(int id)
		{
			var advert = _advertRepository.GetAllInclude(x => x.Id==id , x=> x.User).FirstOrDefault();
			if (advert != null)
			{
				return _mapper.Map<AllAdvertsResponseModel>(advert);
			}
			else
				return null;
		}

		public List<AllAdvertsResponseModel> GetAll()
		{
			var advert = _advertRepository.GetAllInclude(x => x.ApproveStatus==ApproveStatus.Active, x => x.User);
			return _mapper.Map<List<AllAdvertsResponseModel>>(advert);

		}

		public List<AllAdvertsResponseModel> GetMyAdverts(int userId)
		{
			var advert = _advertRepository.GetAllInclude(x => x.UserId == userId, x => x.User);
			return _mapper.Map<List<AllAdvertsResponseModel>>(advert);
		}

		public async Task<bool> ChangeStatu(ChangeAdvertStatuRequestModel request)
		{
			var advert = await _advertRepository.GetById(request.Id);
			if (advert.UserId==request.UserId || request.UserType==UserType.Admin)
			{
				if (request.ApproveStatus == ApproveStatus.Active)
				{
					advert.IsDeleted = false;
					advert.ApproveStatus = ApproveStatus.Active;
				}
				if (request.ApproveStatus == ApproveStatus.Inactive)
				{
					advert.ApproveStatus = ApproveStatus.Inactive;
					advert.IsDeleted = true;
				}
				if (request.ApproveStatus == ApproveStatus.Pasif)
				{
					advert.IsDeleted = true;
					advert.ApproveStatus = ApproveStatus.Pasif;
				}
				var result = await _advertRepository.Update(request.Id, advert);
				return result;
			}
			return false;
		
		}

		public async Task<bool> Update(UpdateAdvertRequestModel request)
		{
			var advert = await _advertRepository.GetById(request.Id);
			advert.Title = request.Title;
			advert.Description = request.Description;
			advert.Price = request.Price;
			advert.Adress = request.Adress;
			advert.Rooms = request.Rooms;
			advert.Mahalle = request.Mahalle;
			advert.Area = request.Area;
			advert.ModifiedDate = request.ModifiedDate;
			advert.Town = request.Town;
			advert.County = request.County;
			advert.Floor = request.Floor;
			var result = await _advertRepository.Update(request.Id, advert);
			return result;
		}

		public List<AllAdvertsResponseModel> Search(string county, string town)
		{
			if (string.IsNullOrEmpty(town) || town == "0" || town == "Adres Seçiniz")
			{
				var countySearch = _advertRepository.GetAll(x => x.County == county && x.ApproveStatus == ApproveStatus.Active);
				return _mapper.Map<List<AllAdvertsResponseModel>>(countySearch);
			}
			var allSearch = _advertRepository.GetAll(x => x.County == county && x.Town == town && x.ApproveStatus == ApproveStatus.Active);
			return _mapper.Map<List<AllAdvertsResponseModel>>(allSearch);

		}

		public List<AllAdvertsResponseModel> GetCounty()
		{
			var list = _advertRepository.GetAll().AsEnumerable().DistinctBy(x => x.County).ToList();
			return _mapper.Map<List<AllAdvertsResponseModel>>(list);

		}

		public List<AllAdvertsResponseModel> GetTown(string CountyId)
		{
			return _mapper.Map<List<AllAdvertsResponseModel>>(_advertRepository.GetAll().Where(x => x.County == CountyId).AsEnumerable().DistinctBy(x => x.Town).ToList());
		}
	}
}
