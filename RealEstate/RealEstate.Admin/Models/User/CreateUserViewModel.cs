using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Admin.Models.User
{
	public class CreateUserViewModel
	{
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
