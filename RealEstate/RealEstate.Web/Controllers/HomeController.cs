using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Web.Models;
using RealEstate.Web.Models.Auth;
using RealEstate.Web.Models.Header;
using RealEstate.Web.Models.Home;
using System.Diagnostics;

namespace RealEstate.Web.Controllers
{
    public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IAdvertService _advertService;
        public HomeController(ILogger<HomeController> logger, INotyfService notyfService, IHttpContextAccessor accessor, 
			IAdvertService advertService) : base(accessor)
        {
            _logger = logger;
			_advertService = advertService;
        }

        public IActionResult PartialMenu()
		{
			var isLogin = false;
			if (GetSessionUser().Id>0)
				isLogin = true;
			var user = new HeaderViewModel
			{
				IsLogin = isLogin,
			};
			return PartialView("_HeaderPartialView", user);
		}
		public List<SelectListItem> GetCounty()
		{
			List<SelectListItem> county = new List<SelectListItem>();
			foreach (var item in _advertService.GetCounty())
			{
				county.Add(new SelectListItem { Text = item.County, Value = item.County });
			}
		return county;
		}
		public JsonResult GetTown(string countyId)
		{
			var townList = _advertService.GetTown(countyId).Select(x=> new SelectListItem
			{
                Text = x.Town,
                Value = x.Town,
            }).ToList();
			
			return Json(townList);
		}
        public IActionResult Index()
		{
			var adverts = _advertService.GetAll();
			var viewModel = new HomeAdvertListView { HomeAdvertModels = adverts, CountyList = GetCounty() };
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
