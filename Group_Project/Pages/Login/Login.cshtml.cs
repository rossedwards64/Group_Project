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

namespace Group_Project.Pages.Login
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }
        public string Message { get; set; }

        public string SessionID;


        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }


            DatabaseConnect dbstring = new DatabaseConnect(); //creating an object from the class
            string DatabaseString = dbstring.DatabaseString(); //calling the method from the class
            Console.WriteLine(DatabaseString);
            SqlConnection conn = new SqlConnection(DatabaseString);
            conn.Open();

            Console.WriteLine(User.Username);
            Console.WriteLine(User.Password);


            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT FirstName, Username, Role FROM UserTable WHERE Username = @UName AND Password = @Pwd";

                command.Parameters.AddWithValue("@UName", User.Username);
                command.Parameters.AddWithValue("@Pwd", User.Password);

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User.FirstName = reader.GetString(0);
                    User.Username = reader.GetString(1);
                    User.Role = reader.GetString(2);
                }


            }

            if (!string.IsNullOrEmpty(User.FirstName))
            {
                SessionID = HttpContext.Session.Id;
                HttpContext.Session.SetString("sessionID", SessionID);
                HttpContext.Session.SetString("username", User.Username);
                HttpContext.Session.SetString("fname", User.FirstName);
               
                if (User.Role=="User")
                {
                    return RedirectToPage("/UserPages/UserIndex");
                }
                else
                {
                    return RedirectToPage("/AdminPages/AdminIndex");
                }

                
            }
            else
            {
                Message = "Invalid Username and Password!";
                return Page();
            }


            
        }


    }
}
