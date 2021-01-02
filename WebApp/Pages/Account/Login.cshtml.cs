using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Pages.Account;

namespace WebApp.Pages
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        static string ReturnUrl;
        [BindProperty]
        public User user { get; set; }

        public void OnGet(string returnUrl = "/")
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPost()
        {

            if (user.login != SuperUser.login || !ComparePwdToAdminPwd(user.password))
            {
                return Unauthorized(); ;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.login),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = true });
            return LocalRedirect("/Admin");
        }

        public static byte[] GetHash(string password)
        {
            byte[] unhashedBytes = Encoding.Unicode.GetBytes(password);

            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedBytes = sha256.ComputeHash(unhashedBytes);

            return hashedBytes;
        }

        public static bool ComparePwdToAdminPwd(string attemptedPassword)
        {
            string base64AttemptedHash = Convert.ToBase64String(GetHash(attemptedPassword));

            return SuperUser.password == base64AttemptedHash;
        }
    }
}
