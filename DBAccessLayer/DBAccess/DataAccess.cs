using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBAccessLayer.DBAccess
{
	public class DataAccess : DbContext
	{
		public DataAccess(DbContextOptions<DataAccess> options) : base(options) { }
		public DbSet<LoginModel> LoginCredentials { get; set; }
		public DbSet<AccessToken> TokenCredentials { get; set; }
	}
}
