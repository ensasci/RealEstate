﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate.Admin.ViewComponents.LayoutComponents
{
    public class _HeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
