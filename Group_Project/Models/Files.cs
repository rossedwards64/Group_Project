using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group_Project.Models
{
    public class Files
    {
        public int FileID { get; set; }

        [Display(Name = "FileName")]
        public string FileName { get; set; }

        [Display(Name = "FileUploader")]
        public string FileUploader { get; set; }

        [Display(Name = "Date")]
        public string Date { get; set; }
    }
}
