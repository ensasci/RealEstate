using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Mahmut;
using RealEstate.API.Models.JwtAuth;
using RealEstate.API.Models.Users;
using RealEstate.Services;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.Domains.Users.Repositories;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		private readonly ITokenService _tokenService;
		public UserController(IUserService userService, IMapper mapper, ITokenService tokenService)
		{
			_userService = userService;
			_mapper = mapper;
			_tokenService = tokenService;
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginUserRequestModel request)
		{

			var user = await _userService.Login(new LoginRequestModel
			{
				Email = request.Email,
				Password = request.Password,
			});
			var loginResponse = new LoginResponseModel();
			if (user.Id > 0)
			{
				var tokenResponse = await _tokenService.GenerateToken(new GenerateTokenRequest { Id = user.Id });
				loginResponse.Id = user.Id;
				loginResponse.AuthToken = tokenResponse.Token;
				loginResponse.AuthenticateResult = true;
				loginResponse.AccessTokenExpireDate = tokenResponse.TokenExpireDate;
				return Ok(new ApiReturn<LoginResponseModel>(loginResponse));
			}
			return BadRequest(new ApiReturn<LoginResponseModel>(loginResponse, false, "İşlem gerçekleştirilemdi"));
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> Register([FromBody] RegisterUserRequestModel request)
		{
			var registerResponse = await _userService.Add(new AddUserRequestModel
			{
				Email = request.Email,
				FullName = request.FullName,
				Password = request.Password,
				Phone = request.Phone,
				UserType = request.UserType,
			});
			if (registerResponse == true)
			{
				return Ok(new ApiReturn<bool>(registerResponse));
			}
			return BadRequest(new ApiReturn<bool>(registerResponse, false, "İşlem gerçekleştirilemdi"));
		}
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordRequest request)
		{
			var passwordResponse = await _userService.SendResetPassword(new ResetPasswordRequest
			{
				Email = request.Email,
				Phone = request.Phone,
			});
			if (passwordResponse == true)
			{
				return Ok(new ApiReturn<bool>(passwordResponse));
			}
			return BadRequest(new ApiReturn<bool>(passwordResponse, false, "İşlem gerçekleştirilemdi"));
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> GetAllUser([FromBody]GetAllUserByAdminRequestModel request)
		{
			var user = await _userService.GetAllUserByAdmin(request);
			return Ok(new ApiReturn<List<UserListItemModel>>(user));
		}

	}
}
