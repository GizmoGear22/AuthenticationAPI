﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class LoginModel
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string? UserName { get; set; }
		[Required]
		[StringLength(50)]
		public string? Password { get; set; }
		[Required]
		[StringLength(64)]
		public string? HashId { get; set; }
	}
}
