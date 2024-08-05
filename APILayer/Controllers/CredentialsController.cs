using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class CredentialsController : Controller
	{
		[Route("PostAuthentication")]
		[HttpPost]
		public async Task<IActionResult> PostAuthentication([FromBody] LoginModel model)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		[Route("AccountCreation")]
		public async Task<IActionResult> AccountCreation([FromBody] CreateUserModel model)
		{
			throw new NotImplementedException(); 
		}

	}
}
