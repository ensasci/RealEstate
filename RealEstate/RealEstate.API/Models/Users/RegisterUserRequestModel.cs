using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.API.Models.Users
{
	public class RegisterUserRequestModel
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set; }
	}
}
