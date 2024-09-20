using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
	public class AppSettings
	{
		public string ConnectionString { get; set; }
		public TheMovieDbSettings TheMovieDb { get; set; }
		public JwtSettings Jwt { get; set; }
		public RabbitSettings Rabbit { get; set; }
	}

	public class TheMovieDbSettings
	{
		public string BaseUrl { get; set; }
		public string Language { get; set; }
		public string ApiKey { get; set; }
	}

	public class JwtSettings
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Key { get; set; }
	}

	public class RabbitSettings
	{
		public string Host { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string QueueName { get; set; }
	}
}
