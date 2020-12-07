using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.LogoutPage
{
    public class LogoutModel : PageModel
    {
        /*
        public string UserName;
        public const string SessionKeyName1 = "username";

        public string FirstName;
        public const string SessionKeyName2 = "fname";

        public string SessionID;
        public const string SessionKeyName3 = "sessionID";
        */

        public void OnGet()
        {
           
            HttpContext.Session.Clear();


        }
    }
}
