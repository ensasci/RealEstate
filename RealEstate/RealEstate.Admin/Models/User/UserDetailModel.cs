using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Admin.Models.User
{
	public class UserDetailModel
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<AllAdvertsResponseModel> UserAdverts { get; set; }
    }
    public class UserAdvertItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string County { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
    }
}
