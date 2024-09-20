using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Admin.ViewComponents.LayoutComponents
{
    public class _ScriptComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
