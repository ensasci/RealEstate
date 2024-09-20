
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Web.Models.Auth;
using RealEstate.Web.Models.Header;
using RealEstate.Web.Models.User.Advert;
using RealEstate.Web.Models.User.Profile;
using System.Security.Cryptography.Xml;

namespace RealEstate.Web.Controllers
{

    [Route("kullanici")]
	public class UserController : BaseController
	{
		private readonly INotyfService _notyfService;
		private readonly IUserService _userService;
		public UserController(IHttpContextAccessor contextAccessor, INotyfService notyfService
			, IUserService userService) : base(contextAccessor)
		{
			_notyfService = notyfService;
			_userService = userService;
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userService.Login(new LoginRequestModel { Email = model.Email, Password = model.Password });
				if (user.Id != 0)
				{
					SetSessionUser(user);
					_notyfService.Success("Giriş Başarılı , Hoş Geldiniz!");
				}
				else
					_notyfService.Error("Hatalı Giriş");
			}
			return RedirectToAction("Index", "Home");
		}
		[Route("kayit")]
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user =await _userService.Add(new AddUserRequestModel
				{
					FullName = model.FullName,
					Email = model.Email,
					Password = model.Password,
					Phone = model.Phone,
					UserType = UserType.Member,
				});
				if (user == true)
					_notyfService.Success("Kayıt başarlı");
				else
					_notyfService.Warning("Email veya Parola Daha öncesinde kullanılmış");

			}
			else
				_notyfService.Success("Geçersiz email veya parola");

			return RedirectToAction("Index", "Home");
		}
		[Route("sifremiUnuttum")]
		public IActionResult ResetPassword()
		{
			return View();
		}
		[Route("sifremiUnuttum")]
		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
		{
			var response = await _userService.SendResetPassword(request);
			if (response == true)
				_notyfService.Success("Şifre yenileme isteği başarılı,Emailini kontrol etmeyi unutma.");
			else
				_notyfService.Warning("Şifre yenileme isteği gerçekleşmedi");
			return View();
		}
		[TypeFilter(typeof(SessionUserCheckAttribute))]
		[Route("cikis")]
		public IActionResult Exit()
		{
			HttpContext.Session.Remove("sessionuser");
			_notyfService.Success("Güvenli şekilde çıkış yapıldı!");
			return RedirectToAction("Index", "Home");
		}
		[TypeFilter(typeof(SessionUserCheckAttribute))]
		[Route("profilim")]
		public async Task<IActionResult> MyProfile()
		{
			var user = await _userService.GetById(GetSessionUser().Id);

			UpdateProfileViewModel viewModel = new UpdateProfileViewModel();
			if (user != null)
			{
				viewModel.Email = user.Email;
				viewModel.FullName = user.FullName;
				viewModel.Id = user.Id;
				viewModel.Password = user.Password;
				viewModel.Phone = user.Phone;
			}
			return View(viewModel);
		}

		[TypeFilter(typeof(SessionUserCheckAttribute))]
		[Route("profilim")]
		[HttpPost]
		public IActionResult MyProfile(UpdateProfileViewModel model)
		{
			if (ModelState.IsValid)
			{
				_userService.Update(new UpdateUserRequestModel
				{
					Id = model.Id,
					FullName = model.FullName,
					Phone = model.Phone,
					Password = model.Password,
					Email = model.Email,
					UserType = UserType.Member,
				});
				_notyfService.Success("Profil bilgileri güncellendi");
			}
			return View(model);
		}
	}
}
