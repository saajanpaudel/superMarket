using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public class eLevelModel
    {
        [Key]
        public int lvl_id { get; set; }
        public string levels { get; set; }
    }
}
