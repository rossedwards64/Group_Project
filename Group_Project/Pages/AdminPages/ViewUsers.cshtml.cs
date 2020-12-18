using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Group_Project.Models;
using Group_Project.Pages.DatabaseConnection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.AdminPages
{
    public class ViewUsersModel : PageModel
    {
        [BindProperty]
        public new List<User> User { get; set; }

        public List<string> UserRole { get; set; } = new List<string> { "User", "Admin" };
        public string Username;
        public const string SessionKeyName1 = "username";

        public string FirstName;
        public const string SessionKeyName2 = "fname";

        public string SessionID;
        public const string SessionKeyName3 = "sessionID";
        public IActionResult OnGet()
        {
            //get the session first!
            Username = HttpContext.Session.GetString(SessionKeyName1);
            FirstName = HttpContext.Session.GetString(SessionKeyName2);
            SessionID = HttpContext.Session.GetString(SessionKeyName3);


            DatabaseConnect dbstring = new DatabaseConnect(); //creating an object from the class
            string DbConnection = dbstring.DatabaseString(); //calling the method from the class
            Console.WriteLine(DbConnection);
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM UserTable";

                var reader = command.ExecuteReader();

                User = new List<User>();
                while (reader.Read())
                {
                    User Row = new User(); //each record found from the table
                    Row.UserID = reader.GetInt32(0);
                    Row.Username = reader.GetString(1);
                    Row.FirstName = reader.GetString(2);
                    Row.Role = reader.GetString(3); 
                    User.Add(Row);
                }
                
            }
            return Page();

        }
    }
}
