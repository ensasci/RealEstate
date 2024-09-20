using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Adverts.Models
{
	public class ChangeAdvertStatuRequestModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public ApproveStatus ApproveStatus { get; set; }
    }
}
