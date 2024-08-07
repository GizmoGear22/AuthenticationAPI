using Models;

namespace DBAccessLayer
{
	public interface IDataHandler
	{
		Task<LoginModel> AddNewUserToDBAsync(LoginModel model);
		Task GetUsersFromRepoAsync();
		Task<LoginModel> GetUserFromRepoAsync(LoginModel model);
	}
}