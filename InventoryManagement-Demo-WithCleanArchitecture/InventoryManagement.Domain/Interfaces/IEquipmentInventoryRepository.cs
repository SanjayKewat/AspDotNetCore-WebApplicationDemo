using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Interfaces
{
    /// <summary>
    /// Repository interface for EquipmentInventory.
    /// </summary>
    public interface IEquipmentInventoryRepository
    {
        Task<IEnumerable<EquipmentInventory>> GetAllAsync();
        Task<EquipmentInventory?> GetByIdAsync(int id);
        Task<EquipmentInventory> AddAsync(EquipmentInventory entity);
        Task UpdateAsync(EquipmentInventory entity);
        Task DeleteAsync(int id);
    }
}
