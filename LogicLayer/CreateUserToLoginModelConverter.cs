using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace LogicLayer
{
	public class CreateUserToLoginModelConverter
	{
		public static LoginModel ConvertModel (CreateUserModel model)
		{
			LoginModel loginModel = new LoginModel
			{
				UserName = model.Name,
				Password = model.Password,
			};
			return loginModel;
		}
	}
}
