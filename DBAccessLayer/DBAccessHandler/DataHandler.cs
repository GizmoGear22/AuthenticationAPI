using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessLayer.DBAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBAccessLayer
{
	public class DataHandler : IDataHandler
	{
		private readonly DataAccess _dataAccess;
		public DataHandler(DataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<LoginModel> AddNewUserToDBAsync(LoginModel model)
		{
			await _dataAccess.LoginCredentials.AddAsync(model);
			await _dataAccess.SaveChangesAsync();
			return model;

		}

		public async Task GetUsersFromRepoAsync()
		{
			await _dataAccess.LoginCredentials.AsNoTracking().ToListAsync();
		}

		public async Task<LoginModel> GetUserFromRepoAsync(LoginModel model)
		{
			var data = await _dataAccess.LoginCredentials.FindAsync(model.UserName);
			return data;
		}
	}
}
