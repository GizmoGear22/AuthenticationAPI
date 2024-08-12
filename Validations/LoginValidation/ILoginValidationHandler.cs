using Models;

namespace Validations.RegexChecker
{
	public interface ILoginValidationHandler
	{
		Task CheckCorrectUserPassword(LoginModel model);
		void CheckIfVoid(LoginModel model);
		void CheckVoidUsername(LoginModel model);
		void CheckVoidPassword(LoginModel model);
	}
}