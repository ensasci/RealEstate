using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Advert
{
	public class FavoriteAdvert:Entity
	{
		public int UserId { get; set; }
		public int AdvertId { get; set; }

		//public virtual User User { get; set; }
		//public virtual Advert Advert { get; set; }
	}
}
