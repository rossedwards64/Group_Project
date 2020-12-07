using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Group_Project.Pages.DatabaseConnection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group_Project.Models;

namespace Group_Project.Pages.DeleteFile
{
    public class DeleteModel : PageModel
    {

      

        [BindProperty]
        public User FileRec { get; set; }

        public readonly IWebHostEnvironment _env;

        //a constructor for the class
        public DeleteModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult OnGet(int? Id)//we receive this Id from View.cs
        {
            DatabaseConnect Dbstring = new DatabaseConnect();
            string DatabaseString = Dbstring.DatabaseString();
            SqlConnection conn = new SqlConnection(DatabaseString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"SELECT * FROM StudentFile WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", Id);

                var reader = command.ExecuteReader();

                FileRec = new User();
                while (reader.Read())
                {
                    FileRec.FileID = reader.GetInt32(0);
                    FileRec.Username = reader.GetString(1); //to display on the html page
                    FileRec.FileName = reader.GetString(2); //to display on the html page
                }

                Console.WriteLine("File name : "+ FileRec.FileName);


            }

            return Page();
        }


        public IActionResult OnPost()
        {

            deletePicture(FileRec.UserID, FileRec.FileName);
            return RedirectToPage("/ViewFile/View");
        }



        public void deletePicture(int Id, string FileName)
        {
            Console.WriteLine("Record Id : "+Id);
            Console.WriteLine("File Name : "+FileName);

            DatabaseConnect dbstring = new DatabaseConnect();
            string DatabaseString = dbstring.DatabaseString();
            SqlConnection conn = new SqlConnection(DatabaseString);
            conn.Open();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = conn;
                command.CommandText = @"DELETE FROM StudentFile WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", Id);

                command.ExecuteNonQuery();
            }
            Console.WriteLine(FileName);
            string RetrieveImage = Path.Combine(_env.WebRootPath, "Files", FileName);
            System.IO.File.Delete(RetrieveImage);
            Console.WriteLine("File has been deleted");

           
        }
    }
}
