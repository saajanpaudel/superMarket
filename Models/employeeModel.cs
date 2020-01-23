using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SuperMarket.Models;
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
            public string email { get; set; }
            public double salary { get; set; }
            public string photo { get; set; }
            [NotMapped]
            public IFormFile UploadImage { get; set; }
    }
}
