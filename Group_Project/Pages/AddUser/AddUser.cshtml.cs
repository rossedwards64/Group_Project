using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Group_Project.Models;
using Group_Project.Pages.DatabaseConnection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group_Project.Pages.AddUser
{
    public class AddUserModel : PageModel
    {
        [BindProperty]
        public new User User { get; set; }

        public List<string> URole { get; set; } = new List<string> { "User", "Admin" };
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DatabaseConnect dbstring = new DatabaseConnect(); //creating an object from the class
            string DbConnection = dbstring.DatabaseString(); //calling the method from the class
            Console.WriteLine(DbConnection);
            SqlConnection conn = new SqlConnection(DbConnection);
            conn.Open();

            Console.WriteLine(User.FirstName);
            Console.WriteLine(User.Username);
            Console.WriteLine(User.Password);
            Console.WriteLine(User.Role);

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"INSERT INTO UserTable (FirstName, Username, Password, Role) VALUES (@FName, @UName, @Pwd, @Role)";

                command.Parameters.AddWithValue("@FName", User.FirstName);
                command.Parameters.AddWithValue("@UName", User.Username);
                command.Parameters.AddWithValue("@Pwd", User.Password);
                command.Parameters.AddWithValue("@Role", User.Role);
                command.ExecuteNonQuery();
            }

            return RedirectToPage("/Index");
        }
    }
}
