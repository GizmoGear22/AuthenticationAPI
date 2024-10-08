﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.DBLogic;
using Microsoft.AspNetCore.Http;
using Models;

namespace LogicLayer.CookieToken
{
	public class CookieTokenLogic : ICookieTokenLogic
	{
		private readonly IHttpContextAccessor _context;
		private readonly IDBAccessLogic _accessLogic;
		public CookieTokenLogic(IHttpContextAccessor context, IDBAccessLogic accessLogic)
		{
			_context = context;
			_accessLogic = accessLogic;
		}

		public void CreateCookie(LoginModel login)
		{
			string token = Guid.NewGuid().ToString();
			var tokenWithNoDashes = token.ToString().Replace("-", "");
			var cookie = new CookieOptions
			{
				Expires = DateTimeOffset.UtcNow.AddHours(1),
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.Strict
			};

			var httpContext = _context.HttpContext;
			httpContext.Response.Cookies.Append("AuthToken", tokenWithNoDashes, cookie);

		}

		public void StoreTokenInDB(LoginModel login, string token)
		{
			AccessToken newToken = new AccessToken
			{
				Id = login.Id,
				UserName = login.UserName,
				TokenId = token
			};

			_accessLogic.StoreTokenInDB(newToken);
		}

	}
}
