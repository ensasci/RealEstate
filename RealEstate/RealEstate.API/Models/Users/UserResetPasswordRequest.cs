namespace RealEstate.API.Models.Users
{
	public class UserResetPasswordRequest
	{
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
