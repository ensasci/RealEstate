using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Users.Models
{
    public class LoginResponseModel
    {
		public bool AuthenticateResult { get; set; }
		public string AuthToken { get; set; }
		public DateTime AccessTokenExpireDate { get; set; }
		public int Id { get; set; }
    }
}
