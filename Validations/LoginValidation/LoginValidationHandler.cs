using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessLayer;
using Models;

namespace Validations.RegexChecker
{
	public class LoginValidationHandler : ILoginValidationHandler
	{
		private readonly IDataHandler _dataHandler;
		public LoginValidationHandler(IDataHandler dataHandler)
		{
			_dataHandler = dataHandler;
		}
		public async Task CheckCorrectUserPassword(LoginModel model)
		{
			var userDbData = await _dataHandler.GetUsersFromRepoAsync();
			var DbUser = userDbData.Where(x => x.UserName == model.UserName).FirstOrDefault();
			if (DbUser?.Password != model.Password)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Incorrect Password");
			}
		}

		public void CheckIfVoid(LoginModel model)
		{
			if (model == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Model is void");
			}
		}

		public void CheckVoidUsername(LoginModel model)
		{
			if (model.UserName == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Input Username");
			}
		}

		public void CheckVoidPassword(LoginModel model)
		{
			if (model.Password == null) 
			{
				throw new ErrorMessageModel("Bad Request", "400", "Input Password");
			}
		}
	}
}
