using System.ComponentModel.DataAnnotations;

namespace RealEstate.Web.Models.User.Advert
{
    public class CreateOrUpdateViewModel
    {
		public int Id { get; set; } = 0;
        [Required(ErrorMessage ="İlan başlığı zorunludur.")]
        public string Title { get; set; }
		[Required(ErrorMessage = "Fiyat alanı zorunludur.")]
		public decimal Price { get; set; }
		[Required(ErrorMessage = "Metrekare alanı zorunludur.")]
		public string Area { get; set; }
        [Required(ErrorMessage = "Oda Sayısı zorunludur.")]
		public string Rooms { get; set; }
        public string Floor { get; set; }
		[Required(ErrorMessage = "Detaylı adres zorunludur.")]
		public string Address { get; set; }
		[Required(ErrorMessage = "il bilgisi zorunludur.")]
		public string County { get; set; }
		[Required(ErrorMessage = "İlçe bilgisi zorunludur.")]
		public string Town { get; set; }
		[Required(ErrorMessage = "Mahalle bilgisi zorunludur.")]
		public string Neighbourhood { get; set; }
		[Required(ErrorMessage = "Detaylı açıklama zorunludur.")]
		public string Description { get; set; }
    }
}
