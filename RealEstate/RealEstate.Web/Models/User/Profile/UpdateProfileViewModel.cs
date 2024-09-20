using RealEstate.Web.Models.Header;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models.User.Profile
{
	public class UpdateProfileViewModel
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad soyad alanı zorunludur.")]
		public string FullName { get; set; }
		[Required(ErrorMessage = "Email alanı zorunludur.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Telefon alanı zorunludur.")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Parola alanı zorunludur.")]
		public string Password { get; set; }
    }
}
