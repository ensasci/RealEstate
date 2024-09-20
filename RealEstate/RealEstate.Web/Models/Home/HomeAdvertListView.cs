
using Microsoft.AspNetCore.Mvc.Rendering;
using RealEstate.Services.Domains.Adverts.Models;

namespace RealEstate.Web.Models.Home
{
	public class HomeAdvertListView
	{
		public List<AllAdvertsResponseModel> HomeAdvertModels { get; set; } = new List<AllAdvertsResponseModel>();
        public int? SelectedCountId { get; set; }
		public List<SelectListItem>? CountyList { get; set; } = new List<SelectListItem>();
		public int? SelectedTownId { get; set; }
		public List<SelectListItem>? TownList { get; set; } = new List<SelectListItem>();
    }
}
