using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core
{
	public class ApiReturn<T>
	{
		public ApiReturn() { }

		public ApiReturn(T data) { this.Data = data; this.Success = true; }
		public ApiReturn(T data, string message) { this.Data = data; this.Message = message; this.Success = true; }
		public ApiReturn(T data, bool success) { this.Data = data; this.Success = success; }
		public ApiReturn(T data, bool success, string message) { this.Data = data; this.Message = message; this.Success = success; }


		public bool Success { get; set; }
		public T Data { get; set; }
		public string Message { get; set; } = "";
		public string InternalMessage { get; set; } = "";
		public List<string> Errors { get; set; }
	}

	public class ApiReturn : ApiReturn<object>
	{
		public ApiReturn() { }
		public ApiReturn(bool success) { Success = success; }
		public ApiReturn(bool success, string message) { Message = message; Success = success; }
	}
}

