using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.AdminPages
{
    public class AdminIndexModel : PageModel
    {
        public string Username;
        public const string SessionKeyName1 = "username";


        public string FirstName;
        public const string SessionKeyName2 = "fname";

        public string SessionID;
        public const string SessionKeyName3 = "sessionID";


        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString(SessionKeyName1);
            FirstName = HttpContext.Session.GetString(SessionKeyName2);
            SessionID = HttpContext.Session.GetString(SessionKeyName3);

            if (string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(SessionID))
            {
                return RedirectToPage("/Login/Login");
            }
            return Page();


        }
    }
}
