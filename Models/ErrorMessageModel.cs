using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class ErrorMessageModel : Exception
	{
		public string? Error {  get; set; }
		public string? ErrorCode { get; set; }

		public ErrorMessageModel(string? error, string? errorCode, string message) : base(message)
		{
			Error = error;
			ErrorCode = errorCode;
		}
	}
}
