using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBLogic;
using Models;
using Validations.RegexChecker;
using Validations.UserCreationValidation;

namespace LogicLayer.APILogic
{
	public class APILogicHandlers : IAPILogicHandlers
	{
		private readonly IDBAccessLogic _dBAccessLogic;
		private readonly IUserCreationValidationHandler _userCreationValidationHandler;
		private readonly ILoginValidationHandler _loginValidationHandler;
		public APILogicHandlers(IDBAccessLogic dBAccessLogic, IUserCreationValidationHandler userCreationValidationHandler, ILoginValidationHandler loginValidationHandler)
		{
			_dBAccessLogic = dBAccessLogic;
			_userCreationValidationHandler = userCreationValidationHandler;
			_loginValidationHandler = loginValidationHandler;
		}
		public async Task CreateUser(CreateUserModel model)
		{

			_userCreationValidationHandler.CheckForMissingPassword(model);
			_userCreationValidationHandler.CheckPasswordMatch(model);
			_userCreationValidationHandler.CheckIfNullCreation(model);
			_userCreationValidationHandler.CheckForMissingName(model);

			var newUser = CreateUserToLoginModelConverter.ConvertModel(model);
			await _userCreationValidationHandler.CheckIfUserExists(model, newUser);

			await _dBAccessLogic.AddUserToDB(newUser);	

		}

		public async Task<List<LoginModel>> GetAllUsers()
		{
			var data = await _dBAccessLogic.GetUsersFromDB();
			return data.ToList();
		}

		public async Task UserAccess(LoginModel model)
		{
			_loginValidationHandler.CheckIfVoid(model);
			_loginValidationHandler.CheckVoidUsername(model);	
			_loginValidationHandler.CheckVoidPassword(model);
			await _loginValidationHandler.CheckCorrectUserPassword(model);

			await _dBAccessLogic.GetUserFromDB(model);	
		}
	}
}
