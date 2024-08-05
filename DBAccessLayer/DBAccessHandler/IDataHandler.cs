using Models;

namespace DBAccessLayer
{
	public interface IDataHandler
	{
		Task<LoginModel> AddNewUserToDBAsync(LoginModel model);
	}
}