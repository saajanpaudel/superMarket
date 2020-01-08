using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SuperMarket.Models;

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
    }
}
