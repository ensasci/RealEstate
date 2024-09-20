
using RealEstate.Core.Advert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.User
{
	public class User : Entity
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Password { get; set; }
		public int UserType { get; set; }
		public virtual List<FavoriteAdvert> FavoriteAdverts { get; set; }
	}

	public enum UserType : int
	{
		Member = 0,
		Admin = 1,
	}
}
