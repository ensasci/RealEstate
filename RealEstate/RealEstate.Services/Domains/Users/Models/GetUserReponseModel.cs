﻿using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Domains.Users.Models
{
	public class GetUserReponseModel
	{
        public int Id { get; set; }
        public string FullName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		//public string  { get; set; }
		public string Password { get; set; }
		public UserType UserType { get; set; }
	}
}
