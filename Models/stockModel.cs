using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SuperMarket.Models;

namespace SuperMarket.Models
{
    public class stockModel
    {
        [Key]
        public int stock_id { get; set; }
        public double cost_price { get; set; }
        public double marked_price { get; set; }
    }
}
