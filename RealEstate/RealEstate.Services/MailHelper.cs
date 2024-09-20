using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services
{
	public static class MailHelper
	{
		private static SmtpClient Client()
		{
			return new SmtpClient
			{
				Port = 587,
				Host = "smtp.gmail.com",
				EnableSsl = true,
				Credentials = new NetworkCredential("enessasci@gmail.com", "eapxztpchtzvyiqb"),
			};
		}
		public static string SendMail(string email)
		{
			var client = Client();
			MailAddress mailAddress = new MailAddress("enessasci@gmail.com", "EvPower", Encoding.UTF8);
			var randomPassword = new Random().Next(100000, 999999).ToString();
			MailMessage message = new MailMessage("enessasci@gmail.com", email)
			{
				IsBodyHtml = true,
				Body = $"Yeni Şifren:{randomPassword} ile giriş yapıp şifreni değiştirmeyi unutma",
				Subject = "Şifre Yenileme",
			};
			try
			{
				client.Send(message);
			}
			catch (Exception ex)
			{
				return null;
				throw;
			}
			return randomPassword;
		}
	}
}
