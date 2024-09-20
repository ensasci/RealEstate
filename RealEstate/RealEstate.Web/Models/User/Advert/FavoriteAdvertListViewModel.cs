using RealEstate.Services.Domains.Adverts.Models;

namespace RealEstate.Web.Models.User.Advert
{
	public class FavoriteAdvertListViewModel
	{
        public List<FavoriteAdvertsResponseModel> FavoriteAdverts { get; set; }=new List<FavoriteAdvertsResponseModel>();
        public int Count { get; set; } = 0;
    }
}
