using RealEstate.Services.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.EntityFramework.Entities
{
	public class Advert:BaseEntity
	{
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Description { get; set; }
        public string Area { get; set; }
        public string Rooms { get; set; }
        public string Floor { get; set; }
        public string County{ get; set; }
        public string Town{ get; set; }
        public string Mahalle{ get; set; }
        public decimal Price{ get; set; }
        public ApproveStatus ApproveStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual List<FavoriteAdvert> FavoriteAdverts { get; set; }
        public virtual User User { get; set; }
    }
    public enum ApproveStatus :int
    {
        Pending=0,
        Active=1,
        Inactive=2,
        Pasif=3,
    }
}
