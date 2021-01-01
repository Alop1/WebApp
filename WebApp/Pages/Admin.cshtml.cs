using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        [BindProperty]
        public News UpdatedNews { get; set; }

        [BindProperty]
        public OpenHours openHours { get; set; }

        public async Task<IActionResult> OnGet(string logout)
        {
            if (logout != null)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return LocalRedirect("/");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (UpdatedNews != null)
            {
                if (UpdatedNews.Body != null)
                {
                    NewsHandler newsHandler = new NewsHandler();
                    newsHandler.SaveNews(UpdatedNews);
                }
            }

            if (openHours != null && (openHours.Days != null || openHours.Houres != null ))
            {
                OpenHoursHandler openHoursHandler = new OpenHoursHandler();
                openHoursHandler.Save(openHours);
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return Redirect("/Index");
        }
    }

}
