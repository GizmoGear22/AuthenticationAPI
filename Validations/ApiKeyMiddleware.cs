using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Validations
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration _config;
		private const string apiKeyHeaderName = "X-Api-Key";

		public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
		{
			_next = next;
			_config = config;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			if (!context.Request.Headers.TryGetValue(apiKeyHeaderName, out var value))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Please input the API Key");
				return;
			}

			var apiKey = _config.GetValue<string>("ApiKey");

			if (!apiKey.Equals(value))
			{
				context.Response.StatusCode = 401;
				await context.Response.WriteAsync("Please input the correct Api Key");
			}

			await _next(context);
		}
	}
}
