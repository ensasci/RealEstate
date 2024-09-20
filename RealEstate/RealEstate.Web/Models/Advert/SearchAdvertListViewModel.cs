using RealEstate.Services.Domains.Adverts.Models;

namespace RealEstate.Web.Models.Advert
{
	public class SearchAdvertListViewModel
	{
        public List<AllAdvertsResponseModel> SearchAdverts { get; set; } = new List<AllAdvertsResponseModel>();
        public int? AdvertCount { get; set; }
    }
}
