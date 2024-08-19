using Models;

namespace DBAccessLayer
{
	public interface IDataHandler
	{
		Task<LoginModel> AddNewUserToDBAsync(LoginModel model);
		Task<List<LoginModel>> GetUsersFromRepoAsync();
		Task<LoginModel> GetUserFromRepoAsync(LoginModel model);
		Task<AccessToken> StoreTokenInRepoAsync(AccessToken model);
	}
}