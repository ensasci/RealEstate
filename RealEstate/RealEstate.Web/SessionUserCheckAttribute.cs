using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RealEstate.Web
{
	public class SessionUserCheckAttribute:ActionFilterAttribute
	{
		private readonly INotyfService _notyfService;
		public SessionUserCheckAttribute(INotyfService notyfService)
		{
			_notyfService = notyfService;
		}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var sessionValue = filterContext.HttpContext.Session.GetString("sessionuser");
			if (string.IsNullOrEmpty(sessionValue))
			{
				_notyfService.Warning("İşlem gerçekleştirilmeden önce giriş yapmanız gerek.");
				//FormsAuthentication.SignOut();
				filterContext.Result =
			   new RedirectToRouteResult(new RouteValueDictionary
						{
							  { "action", "Index" },
							{ "controller", "Home" }
						 });
				return;
			}
		}
	}
	public class SessionUser
	{
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
