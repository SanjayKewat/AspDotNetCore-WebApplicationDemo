using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InventoryManagement.Domain.Entities
{
    /// <summary>
    /// Represents an equipment inventory item.
    /// </summary>
    [Table("EquipmentInventory", Schema = "InventoryManagement")]
    public class EquipmentInventory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string ItemCode { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Make { get; set; } = null!;

        [StringLength(50)]
        public string? ItemModel { get; set; }

        [StringLength(250)]
        public string? TrackingMethod { get; set; }

        [Required]
        [ForeignKey(nameof(ItemGroup))]
        public int ItemGroupId { get; set; }

        public ItemGroup ItemGroup { get; set; } = null!;

        [Required]
        public bool IsVoid { get; set; }
    }

    /// <summary>
    /// Represents an item group.
    /// </summary>
    [Table("ItemGroup", Schema = "InventoryManagement")]
    public class ItemGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemGroupName { get; set; } = null!;

        [Required]
        public bool IsVoid { get; set; }
    }
}