using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessLayer;
using Models;

namespace LogicLayer.DBLogic
{
	public class DBAccessLogic : IDBAccessLogic
	{
		private readonly IDataHandler _handler;
		public DBAccessLogic(IDataHandler handler)
		{
			_handler = handler;
		}

		public async Task AddUserToDB(LoginModel model)
		{
			await _handler.AddNewUserToDBAsync(model);
		}

		public async Task GetUsersFromDB()
		{
			await _handler.GetUsersFromRepoAsync();
		}

		public async Task<LoginModel> GetUserFromDB(LoginModel model)
		{
			var data = await _handler.GetUserFromRepoAsync(model);
			return data;
		}
	}
}
