using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models;

namespace LogicLayer.CookieToken
{
    public class CookieTokenLogic
    {
        private readonly HttpContext _context;
        public CookieTokenLogic(HttpContext context)
        {
            _context = context;
        }

        public void CreateCookie(LoginModel login)
        {
            string token = Guid.NewGuid().ToString();
            var cookie = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            };

            _context.Response.Cookies.Append("AuthToken", token, cookie);
        }

        public void StoreTokenInDB(LoginModel login, string token)
        {
            AccessToken newToken = new AccessToken
            {
                Id = login.Id,
                UserName = login.UserName,
                TokenId = token
            };
        }

    }
}
