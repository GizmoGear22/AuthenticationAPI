using Models;

namespace LogicLayer.CookieToken
{
	public interface ICookieTokenLogic
	{
		void CreateCookie(LoginModel login);
		void StoreTokenInDB(LoginModel login, string token);
	}
}