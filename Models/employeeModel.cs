
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarket.Models
{
    public class employeeModel
    {
            [Key]
            public int emp_id { get; set; }
            [Required]
            public string name { get; set; }
            [Required]
            public string address { get; set; }
            [Required]
            public string email { get; set; }
            [Required]
            public double salary { get; set; }
            [Required]
            public int emp_lvl { get; set; }
            [Required]
            public string photo { get; set; }
            [NotMapped]
            public IFormFile UploadImage { get; set; }
    }
}
