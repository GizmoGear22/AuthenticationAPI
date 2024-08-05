using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessLayer.DBAccess;
using Models;

namespace DBAccessLayer
{
	public class DataHandler
	{
		private readonly DataAccess _dataAccess;
		public DataHandler(DataAccess dataAccess)
		{
			_dataAccess = dataAccess;
		}

		public async Task<LoginModel> AddNewUserToDBAsync(LoginModel model)
		{
			await _dataAccess.AddAsync(model);
			await _dataAccess.SaveChangesAsync();
			return model;

		}
	}
}
