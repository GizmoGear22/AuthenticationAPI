using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBLogic;
using Models;

namespace LogicLayer.AuthLogic
{
	public class AuthLogicHandler : IAuthLogicHandler
	{
		private readonly IDBAccessLogic _dbAccessLogic;
		public AuthLogicHandler(IDBAccessLogic dbAccessLogic)
		{
			_dbAccessLogic = dbAccessLogic;
		}

		public async Task<AccessToken> CreateToken(AccessToken accessToken)
		{
			var data = await _dbAccessLogic.StoreTokenInDB(accessToken);
			return data;
		}
	}
}
