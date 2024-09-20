using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models.Auth
{
	public class SignUpViewModel
	{
        [Required(ErrorMessage ="Ad Soyad alanı boş geçilemez")]
        public string FullName { get; set; }
		[Required(ErrorMessage = "Telefon alanı boş geçilemez")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Email alanı boş geçilemez")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Parola alanı boş geçilemez")]
		public string Password { get; set; }
    }
}
