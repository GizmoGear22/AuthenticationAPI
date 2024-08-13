using Models;

namespace Validations.UserCreationValidation
{
	public interface IUserCreationValidationHandler
	{
		void CheckForMissingName(CreateUserModel model);
		void CheckForMissingPassword(CreateUserModel model);
		void CheckForMissingPasswordCheck(CreateUserModel model);
		void CheckIfNullCreation(CreateUserModel model);
		void CheckPasswordMatch(CreateUserModel model);
		Task CheckIfUserExists(LoginModel loginModel);
	}
}