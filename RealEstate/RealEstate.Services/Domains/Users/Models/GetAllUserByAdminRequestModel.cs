using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Users.Models
{
	public class GetAllUserByAdminRequestModel
	{
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }
}
