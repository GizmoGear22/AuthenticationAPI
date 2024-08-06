using Models;

namespace LogicLayer.DBLogic
{
	public interface IDBAccessLogic
	{
		Task AddUserToDB(LoginModel model);
	}
}