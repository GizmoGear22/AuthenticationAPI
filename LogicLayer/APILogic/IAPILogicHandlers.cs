using Models;

namespace LogicLayer.APILogic
{
	public interface IAPILogicHandlers
	{
		Task CreateUser(CreateUserModel model);
		Task UserAccess(LoginModel model);
	}
}