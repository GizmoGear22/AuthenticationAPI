﻿using LogicLayer.APILogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace APILayer.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class CredentialsController : Controller
	{
		private readonly IAPILogicHandlers _handlers;
		public CredentialsController(IAPILogicHandlers handlers)
		{
			_handlers = handlers;
		}

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
			if (ModelState.IsValid)
			{
				await _handlers.CreateUser(model);
				return Ok(model);
			} else
			{
				return BadRequest("Improper Request");
			}
			
		}

	}
}
