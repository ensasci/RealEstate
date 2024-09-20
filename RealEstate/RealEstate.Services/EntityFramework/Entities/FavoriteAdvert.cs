using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.EntityFramework.Entities
{
	public class FavoriteAdvert :BaseEntity
	{
        public int UserId { get; set; }
        public int AdvertId { get; set; }
        public virtual User  User { get; set; }
        //public int UserId { get; set; }
        //public int AdvertId { get; set; }
        //public virtual List<User> Users { get; set; }
        public virtual Advert Advert { get; set; }

    }
}
