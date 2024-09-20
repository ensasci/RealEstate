using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Admin.ViewComponents.LayoutComponents
{
    public class _FooterComponentPartial :ViewComponent
    {
        public IViewComponentResult Invoke()
        { return View(); }

    }
}
