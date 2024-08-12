using Models;

namespace Validations.RegexChecker
{
	public interface ILoginValidationHandler
	{
		Task<bool> CheckCorrectUserPassword(LoginModel model);
	}
}