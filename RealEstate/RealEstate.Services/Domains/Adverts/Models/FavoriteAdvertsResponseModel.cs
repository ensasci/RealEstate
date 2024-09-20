using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts.Models
{
	public class FavoriteAdvertsResponseModel
	{
		public int Id { get; set; }
		public int AdvertId { get; set; }
		public string Title { get; set; }
		public string Adress { get; set; }
		public string Description { get; set; }
		public string Rooms { get; set; }
		public string County { get; set; }
		public string Town { get; set; }
		public decimal Price { get; set; }
	}
}
