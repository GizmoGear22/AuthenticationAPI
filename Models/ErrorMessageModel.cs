using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class ErrorMessageModel
	{
		public string Message { get; set; }
		public string ErrorCode { get; set; }
	}
}
