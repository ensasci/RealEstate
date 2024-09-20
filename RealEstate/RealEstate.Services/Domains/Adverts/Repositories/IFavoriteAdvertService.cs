using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts.Repositories
{
    public interface IFavoriteAdvertService
    {
        Task<bool> AddToFavorite(AddToFavoriteRequestModel request);
        Task<bool> RemoveFromFavorite(int id);
        Task<bool> IsThereFavorite(int advertId, int userId);

        List<FavoriteAdvertsResponseModel> GetFavoriteAdverts(int id);
    }
}
