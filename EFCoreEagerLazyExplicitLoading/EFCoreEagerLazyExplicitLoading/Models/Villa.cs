using System.ComponentModel.DataAnnotations;

namespace EFCoreEagerLazyExplicitLoading.Models
{
    public class Villa
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }

        // Many to Many Relationship
        public ICollection<VillaAmenity> VillaAmenities { get; set; }
    }
}
