using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBLogic;
using Models;

namespace LogicLayer.APILogic
{
	public class APILogicHandlers : IAPILogicHandlers
	{
		private readonly IDBAccessLogic _dBAccessLogic;
		public APILogicHandlers(IDBAccessLogic dBAccessLogic)
		{
			_dBAccessLogic = dBAccessLogic;
		}
		public async Task CreateUser(CreateUserModel model)
		{
			if (model.Password == model.checkPassword)
			{
				var newModel = CreateUserToLoginModelConverter.ConvertModel(model);
				await _dBAccessLogic.AddUserToDB(newModel);
			}
		}

		public async Task<List<LoginModel>> GetAllUsers()
		{
			var data = await _dBAccessLogic.GetUsersFromDB();
			return data.ToList();
		}

		public async Task UserAccess(LoginModel model)
		{
			bool[] ErrorArray = new bool[]
			{

			};

			await _dBAccessLogic.GetUserFromDB(model);	
		}
	}
}
