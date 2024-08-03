using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBAccessLayer.DBAccess
{
	public class DBAccess : DbContext
	{
		public DBAccess(DbContextOptions<DBAccess> options) : base(options) { }
		public DbSet<LoginModel> LoginCredentials { get; set; }
	}
}
