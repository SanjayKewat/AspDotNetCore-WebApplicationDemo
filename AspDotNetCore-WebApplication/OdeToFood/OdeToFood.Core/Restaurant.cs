using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    [Table("Restaurant")]
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //Here apply to validation required & string length
        [Required,StringLength(80)]
        public string Name { get; set; }

        //Here apply to validation required & string length
        [Required, StringLength(300)]
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
