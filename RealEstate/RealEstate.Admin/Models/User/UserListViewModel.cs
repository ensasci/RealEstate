using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Admin.Models.User
{
	public class UserListViewModel
	{
        public List<UserListItemModel> Users { get; set; }

    }
}
