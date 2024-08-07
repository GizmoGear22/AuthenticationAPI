using Models;

namespace LogicLayer.APILogic
{
	public interface IAPILogicHandlers
	{
		Task CreateUser(CreateUserModel model);
		Task<List<LoginModel>> GetAllUsers();
		Task UserAccess(LoginModel model);
	}
}