using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project.Models
{
    public class User
    {
        public int UserID { get; set;}

       
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string FileName { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }
        public int FileID { get; internal set; }
    }
}
