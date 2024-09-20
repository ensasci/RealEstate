using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Admin.ViewComponents.LayoutComponents
{
	public class _HeadComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
