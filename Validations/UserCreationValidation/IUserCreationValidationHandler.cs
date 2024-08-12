using Models;

namespace Validations.UserCreationValidation
{
	public interface IUserCreationValidationHandler
	{
		bool CheckForMissingName(CreateUserModel model);
		bool CheckForMissingPassword(CreateUserModel model);
		bool CheckForMissingPasswordCheck(CreateUserModel model);
		bool CheckIfNullCreation(CreateUserModel model);
		bool CheckPasswordMatch(CreateUserModel model);
	}
}