using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace EFCoreEagerLazyExplicitLoading.Models
{
    public class VillaAmenity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Villa")]
        public int VillaId { get; set; }
        //One to many relationship
        public Villa Villa { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
