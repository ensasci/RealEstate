using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Web.Models.User.Advert
{
	public class MyAdvertListViewModel
	{
        public List<AllAdvertsResponseModel> MyAdverts { get; set; }=new List<AllAdvertsResponseModel>();
    }
}
