using Microsoft.AspNetCore.Mvc;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Web.Models.Advert;
using RealEstate.Services.EntityFramework.Entities;
using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Notyf;
using RealEstate.Web.Models.User.Advert;
using RealEstate.Services.Domains.Adverts.Repositories;
using RealEstate.Services.Domains.Adverts.Models;

namespace RealEstate.Web.Controllers
{
    [Route("ilanlar")]
    public class AdvertController : BaseController
    {

        private readonly IAdvertService _advertService;
        private readonly IFavoriteAdvertService _favoriteAdvertService;
        private readonly INotyfService _notyfService;
        public AdvertController(
            IHttpContextAccessor httpContextAccessor
            , INotyfService notyfService, IAdvertService advertService
            , IFavoriteAdvertService favoriteAdvertService) : base(httpContextAccessor)
        {
            _advertService = advertService;
            _favoriteAdvertService = favoriteAdvertService;
            _notyfService = notyfService;
        }
        [Route("ilanDetay/{id}")]
        public async Task<IActionResult> AdvertDetail(int id)
        {
            var viewModel = await _advertService.GetAdvert(id);
            return View(viewModel);
        }

        [TypeFilter(typeof(SessionUserCheckAttribute))]
        [Route("favoriyeEkle/{id}/{advertUserId}")]
        public async Task<IActionResult> AddToAdvert(int id, int advertUserId)
        {
            if (GetSessionUser().Id != advertUserId)
            {
              var respone =await  _favoriteAdvertService.AddToFavorite(new AddToFavoriteRequestModel { AdvertId = id, UserId = GetSessionUser().Id, });
                if (respone==true)
                {
					_notyfService.Success("İlan favorilere eklendi");
					return RedirectToAction("favoriilanlarim", "ilanlar");
				}
            }
            _notyfService.Error("İlan favorilere eklenemedi");
            return RedirectToAction("ilanDetay", "ilanlar", new { id = id });

        }
        [Route("favoriilanlarim")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        public IActionResult BookmarkList()
        {
            var favoriteAdverts = _favoriteAdvertService.GetFavoriteAdverts(GetSessionUser().Id);
            var viewModel = new FavoriteAdvertListViewModel { FavoriteAdverts = favoriteAdverts, Count = favoriteAdverts.Count };
            return View(viewModel);
        }
        [Route("ilanlarim")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        public IActionResult MyAdverts()
        {
            var viewModel = _advertService.GetMyAdverts(GetSessionUser().Id);
            return View(viewModel);
        }
        [Route("ilanolustur/{id}")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        public async Task<IActionResult> CreateOrUpdate(int id)
        {
            var viewModel = new CreateOrUpdateViewModel();
            if (id > 0)
            {
                var advert = await _advertService.GetAdvert(id);
                viewModel.Id=advert.Id;
                viewModel.Area = advert.Area;
                viewModel.Address = advert.Adress;
                viewModel.Price = advert.Price;
                viewModel.Neighbourhood = advert.Mahalle;
                viewModel.County = advert.County;
                viewModel.Description = advert.Description;
                viewModel.Floor = advert.Floor;
                viewModel.Rooms = advert.Rooms;
                viewModel.Title = advert.Title;
                viewModel.Town = advert.Town;
            }
            return View(viewModel);
        }
        [Route("ilanolustur/{id}")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromRoute] int id, CreateOrUpdateViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    await _advertService.Update(new UpdateAdvertRequestModel
                    {
                        Id = model.Id,
                        Area = model.Area,
                        County = model.County,
                        Description = model.Description,
                        Mahalle = model.Neighbourhood,
                        Price = model.Price,
                        Title = model.Title,
                        Town = model.Town,
                        ModifiedDate = DateTime.Now,
                        Floor = model.Floor,
                        Adress = model.Address,
                        Rooms = model.Rooms,
                    });
                    _notyfService.Success("İlan Güncellemesi başarılı şekilde gerçekleşti");
                }
                else
                {
                    await _advertService.Add(new AddAdvertRequestModel
                    {
                        Area = model.Area,
                        County = model.County,
                        CreatedDate = DateTime.Now,
                        Description = model.Description,
                        Mahalle = model.Neighbourhood,
                        Price = model.Price,
                        Title = model.Title,
                        Town = model.Town,
                        UserId = GetSessionUser().Id,
                        ModifiedDate = DateTime.Now,
                        Floor = model.Floor,
                        Adress = model.Address,
                        Rooms = model.Rooms,
                    });
                    _notyfService.Success("İlanınız onaylanmak üzere gönderilmiştir.");
                }
            }
            return RedirectToAction("ilanlarim", "ilanlar");
        }

        [Route("favoriSil/{id}")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            await _favoriteAdvertService.RemoveFromFavorite(id);
            _notyfService.Success("İlan favorilerden kaldırıldı");
            return RedirectToAction("favoriilanlarim", "ilanlar");
        }
        [Route("ilanSil/{id}")]
        [TypeFilter(typeof(SessionUserCheckAttribute))]
        public async Task<IActionResult> DeleteAdvert(int id)
        {
            await _advertService.ChangeStatu(new ChangeAdvertStatuRequestModel { Id=id,UserId=GetSessionUser().Id,ApproveStatus=ApproveStatus.Pasif});
            _notyfService.Success("İlan yayından kaldırıldı");
            return RedirectToAction("ilanlarim", "ilanlar");
        }

        //[Route("il={countyId}/ilce={townId}")]
        [Route("arama")]
        public async Task<IActionResult> Search(string SelectedCountId, string SelectedTownId)
        {
            var adverts = _advertService.Search(SelectedCountId, SelectedTownId);
            if (adverts.Count==0)
            {
                _notyfService.Warning("Aradığınız kriterlere göre eşleşen ilan bulunmadı.");
                return RedirectToAction("Index","Home");
            }
            var viewModel = new SearchAdvertListViewModel
            {
                SearchAdverts = adverts,
                AdvertCount = adverts.Count
            };
            return View(viewModel);
        }


    }
}
