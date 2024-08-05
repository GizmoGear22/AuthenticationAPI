using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class CreateUserModel
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(50)]
		public string Password { get; set; }
		[Required]
		[StringLength(50)]
		public string checkPassword { get; set; }
	}
}
