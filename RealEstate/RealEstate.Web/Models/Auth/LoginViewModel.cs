using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models.Auth
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Email boş geçilemez.")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Şifre boş geçilemez.")]
		public string Password { get; set; }
	}
}
