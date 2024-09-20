using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts.Models
{
    public class AddToFavoriteRequestModel
    {
        public int AdvertId { get; set; }
        public int UserId { get; set; }
    }
}
