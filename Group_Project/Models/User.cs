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

        [Display(Name ="Role")]
        public string Role { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

#nullable enable
        [Display(Name = "File Name")]
        public string? FileName { get; set; }
    }
}
