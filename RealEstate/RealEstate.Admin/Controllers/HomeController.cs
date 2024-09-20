using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Admin.Models;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Services.EntityFramework.Entities;
using System.Diagnostics;

namespace RealEstate.Admin.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IUserService _userService;
		private readonly IAdvertService _advertService;

		public HomeController(ILogger<HomeController> logger, IUserService userService,
			IAdvertService advertService)
		{
			_logger = logger;
			_userService = userService;
			_advertService = advertService;
		}
		public async Task<IActionResult> Index()
		{
			var adverts = _advertService.GetAdminAdverts().ToList();
			var viewModel = new HomeViewModel
			{
				UserCount = _userService.GetAll().Count(),
				PendingAdvert =adverts.Count(x=> x.ApproveStatus==ApproveStatus.Pending), 
				ActiveAdvertCount = adverts.Count(x => x.ApproveStatus == ApproveStatus.Active),
				DectiveAdvertCount = adverts.Count(x=> x.ApproveStatus==ApproveStatus.Inactive),
			};
			return View(viewModel);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
