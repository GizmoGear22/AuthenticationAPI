using Models;

namespace LogicLayer.AuthLogic
{
	public interface IAuthLogicHandler
	{
		Task<AccessToken> CreateToken(AccessToken accessToken);
	}
}