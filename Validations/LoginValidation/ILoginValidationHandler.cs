using Models;

namespace Validations.RegexChecker
{
	public interface ILoginValidationHandler
	{
		Task<bool> CheckUserPassword(LoginModel model);
	}
}