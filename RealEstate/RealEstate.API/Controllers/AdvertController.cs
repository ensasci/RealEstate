using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using RealEstate.API.Models.Adverts;
using RealEstate.Services;
using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class AdvertController : ControllerBase
	{
		private readonly IAdvertService _advertService;
		private readonly IFavoriteAdvertService _favoriteAdvertsService;
		private readonly IUserService _userService;

		public AdvertController(IAdvertService advertService, IFavoriteAdvertService favoriteAdvertService, IUserService userService)
		{
			_advertService = advertService;
			_favoriteAdvertsService = favoriteAdvertService;
			_userService = userService;
		}
		[HttpGet]
	
		public IActionResult GetAdverts()
		{
			var model = _advertService.GetAll();
			return Ok(new ApiReturn<List<AllAdvertsResponseModel>>(model));
		}
		[HttpGet]
		[Authorize]
		public IActionResult GetAdminAdverts()
		{
			var model = _advertService.GetAdminAdverts();
			return Ok(new ApiReturn<List<AllAdvertsResponseModel>>(model));
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> AdvertDetail(int id)
		{
			var model = await _advertService.GetAdvert(id);
			return Ok(new ApiReturn<AllAdvertsResponseModel>(model));
		}

		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> FavoriteAdverts(int id)
		{
			var model =  _favoriteAdvertsService.GetFavoriteAdverts(id);
			return Ok(new ApiReturn<List<FavoriteAdvertsResponseModel>>(model));
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddToFavoriteAdvert([FromBody] AddFavoriteRequest request)
		{
			var model= await _favoriteAdvertsService.AddToFavorite(new AddToFavoriteRequestModel { AdvertId=request.Id,UserId=request.AdvertUserId});
			return Ok(new ApiReturn<bool>(model));
		}
		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> DeleteFavorite(int id)
		{
		  var model =  await _favoriteAdvertsService.RemoveFromFavorite(id);
			if (model==true)
			{
				return Ok(new ApiReturn<bool>(model));
			}
			return BadRequest(new ApiReturn<bool>(model,model,"İşlem gerçekleştirilemdi"));
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> CreateAdvert([FromBody] AddAdvertRequestModel request)
		{
		 var model=	 await _advertService.Add(request);
			if (model==true)
			{
				return Ok(new ApiReturn<bool>(model));

			}
			return BadRequest(new ApiReturn<bool>(model, model, "İşlem gerçekleştirilemdi"));
		}
		[Authorize]
		[HttpPost]
		public async Task<IActionResult> ChangeStatu([FromBody] ChangeAdvertStatuRequestModel request)
		{
			var isAdmin = await _userService.IsAdmin(request.Id);
			if (isAdmin == true)
				request.UserType = UserType.Admin;
			else
				request.UserType = UserType.Member;
			var model = await _advertService.ChangeStatu(request);
			
			if (model == true)
			{
				return Ok(new ApiReturn<bool>(model));

			}
			return BadRequest(new ApiReturn<bool>(model, model, "İşlem gerçekleştirilemdi"));
		}


	}
}
