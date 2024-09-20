using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.EntityFramework.Entities
{
	public class User :BaseEntity
	{
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public string  { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public virtual List<FavoriteAdvert> FavoriteAdverts { get; set; }
        public virtual List<Advert> Adverts { get; set; }
    }

    public enum UserType : int
    {
        Member=0,
        Admin=1,
    }
}
