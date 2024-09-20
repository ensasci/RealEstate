using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Admin.Models.Advert
{
    public class AdvertListViewModel
    {
        public List<AllAdvertsResponseModel> Adverts { get; set; } = new List<AllAdvertsResponseModel>();
    }
	//public class AdvertListItemModel
	//{
 //       public int Id { get; set; }
 //       public int UserId { get; set; }
 //       public string FullName { get; set; }
 //       public string Phone { get; set; }
 //       public string Adress { get; set; }
 //       public ApproveStatus ApproveStatus { get; set; }
 //   }
}
