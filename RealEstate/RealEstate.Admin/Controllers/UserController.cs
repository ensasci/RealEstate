using Microsoft.AspNetCore.Mvc;
using RealEstate.Admin.Models.User;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Services.EntityFramework.Entities;
using System.Linq;


namespace RealEstate.Admin.Controllers
{
    [Route("kullanici")]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IAdvertService _advertService;
		public UserController(IUserService userService, IAdvertService advertService)
		{
			_userService = userService;
			_advertService = advertService;
		}
		[Route("tumKullanicilar")]
		public IActionResult UsersList()
		{
			var userList = _userService.GetAll();
			var viewModel = new UserListViewModel { Users = userList };
			return View(viewModel);
		}
		[Route("kullaniciOlustur")]
		public IActionResult CreateUser()
		{
			return View();
		}
		[Route("kullaniciOlustur")]
		[HttpPost]
		public IActionResult CreateUser(CreateUserViewModel viewModel)
		{
			_userService.Add(new AddUserRequestModel
			{
				FullName = viewModel.FullName,
				Email = viewModel.Email,
				Password = viewModel.Password,
				Phone = viewModel.Phone,
				UserType = UserType.Admin,
			});
			return RedirectToAction("kullanici","tumKullanicilar");
		}
		[Route("kullaniciDetay/{id}")]
		public async Task<IActionResult> UserDetail(int id)
		{
			var user = await _userService.GetById(id);
			var adverts = _advertService.GetMyAdverts(id);
			var viewModel = new UserDetailModel
			{
				UserAdverts = adverts,
				Email = user.Email,
				Id = id,
				FullName = user.FullName,
				Phone = user.Phone,
			};
			return View(viewModel);
		}
	}
}
