using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using RealEstate.Admin.Models.Advert;
using RealEstate.Services.EntityFramework.Entities;
using RealEstate.Services.Domains.Adverts.Models;
using RealEstate.Services.Domains.Adverts.Repositories;

namespace RealEstate.Admin.Controllers
{
    [Route("ilan")]
    public class AdvertController :Controller
    {
        private readonly IAdvertService _advertService;
		private readonly IConfiguration _configuration;

		public AdvertController(IAdvertService advertService, IConfiguration configuration)
		{
			_advertService = advertService;
			_configuration = configuration;
		}
		[Route("tumilanlar")]
        public IActionResult AdvertList()
        {
            var adverts = _advertService.GetAdminAdverts();
			var viewModel = new AdvertListViewModel
			{
				Adverts = adverts
			};
            return View(viewModel);
        }
		[Route("ilanGuncelle/{id}/{statuId}")]
		public async Task<IActionResult> AdvertStatusChange(int id,int statuId)
        {
			var statu = ApproveStatus.Pending;
			if (statuId==1)
				statu = ApproveStatus.Active;
			if (statuId == 2)
				statu = ApproveStatus.Inactive;
			if (statuId == 3)
				statu = ApproveStatus.Pasif;
           await _advertService.ChangeStatu(new ChangeAdvertStatuRequestModel { Id=id,ApproveStatus=statu,UserType=UserType.Admin});
            return RedirectToAction("tumilanlar","ilan");
        }

		[Route("ilanDetayi/{id}")]
		public async Task<IActionResult> AdvertDetail(int id)
		{
			var viewModel = await _advertService.GetAdvert(id);
			return View(viewModel);
		}
		// Örnek  api bağlantısı
		//[Route("ilanDetayi/{id}")]
		//public async Task<IActionResult> AdvertDetail(int id)
		//{
		//	var viewModel = new AllAdvertsResponseModel();
		//	var client = new HttpClient();
		//	var request = new HttpRequestMessage(HttpMethod.Get, $"{_configuration["ApiUrl"]}/Advert/GetByUserAdvert/{id}");
		//	request.Headers.Add("Authorization", $"bearer {_configuration["Token"]}");
		//	var response = await client.SendAsync(request);
		//	response.EnsureSuccessStatusCode();
		//	var responseString = await response.Content.ReadAsStringAsync();
		//	if (response.IsSuccessStatusCode==true)
		//	{
		//		var apiResponse = JsonConvert.DeserializeObject<ApiReturn<AllAdvertsResponseModel>>(responseString);
		//		viewModel = apiResponse.Data;
				
		//	}
		//	return View(viewModel);
		//}
	}
}
