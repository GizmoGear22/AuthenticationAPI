using Models;

namespace LogicLayer.DBLogic
{
	public interface IDBAccessLogic
	{
		Task AddUserToDB(LoginModel model);
		Task<List<LoginModel>> GetUsersFromDB();
		Task<LoginModel> GetUserFromDB(LoginModel model);
		Task<AccessToken> StoreTokenInDB(AccessToken model);
	}
}