using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group_Project.Models;
using Group_Project.Pages.DatabaseConnection;

namespace Group_Project.Pages.ViewFile
{
    public class ViewModel : PageModel
    {
        public List<User> FileRec { get; set; }
        public void OnGet()
        {
            DatabaseConnect Dbstring = new DatabaseConnect();
            string DatabaseString = Dbstring.DatabaseString();
            SqlConnection conn = new SqlConnection(DatabaseString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM StudentFile";

                var reader = command.ExecuteReader();

                FileRec = new List<User>();

                while (reader.Read())
                {
                    User rec = new User();
                    rec.Id = reader.GetInt32(0); // we need this to send the Id to Delete page for another enquiry
                    rec.UserName = reader.GetString(1);
                    rec.FileName = reader.GetString(2);
                    FileRec.Add(rec);
                }
            }

        }
    }
}
