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

		public async Task<List<LoginModel>> GetUsersFromRepoAsync()
		{
			var data = await _dataAccess.LoginCredentials.AsNoTracking().ToListAsync();
			return data;
		}

		public async Task<LoginModel> GetUserFromRepoAsync(LoginModel model)
		{
			//var data = await _dataAccess.LoginCredentials.FindAsync(model.UserName);
			var data = await _dataAccess.LoginCredentials.Where(x => x.UserName == model.UserName).FirstOrDefaultAsync();
			return data;
		}

		public async Task<AccessToken> StoreTokenInRepoAsync(AccessToken model)
		{
			await _dataAccess.TokenCredentials.AddAsync(model);
			await _dataAccess.SaveChangesAsync();
			return model;
			
		}
	}
}
