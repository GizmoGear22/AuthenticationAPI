using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using DBAccessLayer;

namespace Validations.UserCreationValidation
{
	public class UserCreationValidationHandler : IUserCreationValidationHandler
	{
		private readonly IDataHandler _handler;
		public UserCreationValidationHandler(IDataHandler handler)
		{
			_handler = handler;
		}
		public void CheckPasswordMatch(CreateUserModel model)
		{
			if (model.Password != model.checkPassword)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Passwords Don't Match");
			}
		}

		public void CheckIfNullCreation(CreateUserModel model)
		{
			if (model == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Model is null");
			}
		}

		public void CheckForMissingName(CreateUserModel model)
		{
			if (model.Name == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Username is missing");
			}
		}

		public void CheckForMissingPassword(CreateUserModel model)
		{
			if (model.Password == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Password is missing");
			}		}

		public void CheckForMissingPasswordCheck(CreateUserModel model)
		{
			if (model.checkPassword == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Password Check is missing");
			}
		}

		public async Task CheckIfUserExists(CreateUserModel model, LoginModel loginModel)
		{
			if (model.Name == loginModel.UserName)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Username already exists");
			}
		}

	}
}
