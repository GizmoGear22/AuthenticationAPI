using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Validations.UserCreationValidation
{
	public class UserCreationValidationHandler : IUserCreationValidationHandler
	{
		public bool CheckPasswordMatch(CreateUserModel model)
		{
			if (model.Password == model.checkPassword)
			{
				return true;
			}
			else
			{
				throw new ErrorMessageModel("Bad Request", "400", "Passwords Don't Match");
			}
		}

		public bool CheckIfNullCreation(CreateUserModel model)
		{
			if (model != null)
			{
				return true;
			}
			else
			{
				throw new ErrorMessageModel("Bad Request", "400", "Model is null");
			}
		}

		public bool CheckForMissingName(CreateUserModel model)
		{
			if (model.Name == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Username is missing");
			}
			return true;
		}

		public bool CheckForMissingPassword(CreateUserModel model)
		{
			if (model.Password == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Password is missing");
			}
			return true;
		}

		public bool CheckForMissingPasswordCheck(CreateUserModel model)
		{
			if (model.checkPassword == null)
			{
				throw new ErrorMessageModel("Bad Request", "400", "Password Check is missing");
			}
			return true;
		}

	}
}
