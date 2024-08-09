﻿using System;
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
		public async Task<bool> CheckUserPassword(LoginModel model)
		{
			var userDbData = await _dataHandler.GetUsersFromRepoAsync();
			var DbUser = userDbData.Where(x => x.UserName == model.UserName).FirstOrDefault();
			if (DbUser?.Password == model.Password && DbUser != null)
			{
				return true;
			}
			else
			{
				string? message = "Wrong Password";
				string? errorCode = "200";
				return false;
			}

		}
	}
}
