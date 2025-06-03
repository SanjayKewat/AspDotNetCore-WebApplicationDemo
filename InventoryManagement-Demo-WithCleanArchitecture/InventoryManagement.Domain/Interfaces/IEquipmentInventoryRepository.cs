using InventoryManagement.Domain.Entities;

namespace InventoryManagement.Domain.Interfaces
{
    /// <summary>
    /// Repository interface for EquipmentInventory.
    /// </summary>
    public interface IEquipmentInventoryRepository
    {
        //Getting Data using EF Core
        //Task<IEnumerable<EquipmentInventory>> GetAllAsync();
        Task<List<EquipmentInventory>> GetAllAsync();
        Task<EquipmentInventory?> GetByIdAsync(int id);
        Task<EquipmentInventory> AddAsync(EquipmentInventory entity);
        Task UpdateAsync(EquipmentInventory entity);
        Task DeleteAsync(int id);
    }
}
