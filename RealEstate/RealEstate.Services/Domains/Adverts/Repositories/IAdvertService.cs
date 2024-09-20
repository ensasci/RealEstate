using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts.Repositories
{
    public interface IAdvertService
    {
        Task<bool> Add(AddAdvertRequestModel request);
        Task<bool> ChangeStatu(ChangeAdvertStatuRequestModel request);
        Task<bool> Update(UpdateAdvertRequestModel request);
        List<AllAdvertsResponseModel> GetAll();
        List<AllAdvertsResponseModel> GetCounty();
        List<AllAdvertsResponseModel> GetTown(string CountyId);

        List<AllAdvertsResponseModel> Search(string county, string town);
        List<AllAdvertsResponseModel> GetAdminAdverts();
        Task<AllAdvertsResponseModel> GetAdvert(int id);
        List<AllAdvertsResponseModel> GetMyAdverts(int userId);

    }
}
