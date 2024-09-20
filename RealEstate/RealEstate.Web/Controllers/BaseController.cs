using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.Services.Domains.Users.Models;
using RealEstate.Services.EntityFramework.Entities;

namespace RealEstate.Web.Controllers
{
	public class BaseController : Controller
	{
		private readonly IHttpContextAccessor _contextAccessor;
		public BaseController(IHttpContextAccessor contextAccessor)
		{
			_contextAccessor = contextAccessor;
		}

		public SessionUser GetSessionUser()
		{
			var sessionValue = _contextAccessor.HttpContext.Session.GetString("sessionuser");
			if (string.IsNullOrEmpty(sessionValue))
			{
				return new SessionUser();
			}
			var sessionUser = JsonConvert.DeserializeObject<SessionUser>(sessionValue);
			if (sessionUser == null)
			{
				return new SessionUser();
			}
			return sessionUser;
		}
		public void SetSessionUser(LoginResponseModel user)
		{
			var sesionModel =new SessionUser
			{
				Id = user.Id,
			};
			var sessionUserJson = JsonConvert.SerializeObject(sesionModel);
			HttpContext.Session.SetString("sessionuser", sessionUserJson);

		}
	}
}
