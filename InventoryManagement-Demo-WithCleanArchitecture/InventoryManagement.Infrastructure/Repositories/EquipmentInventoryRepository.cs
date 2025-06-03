using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;
using InventoryManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.Repositories
{

    public class EquipmentInventoryRepository : IEquipmentInventoryRepository
    {
        private readonly AppDbContext _context;

        public EquipmentInventoryRepository(AppDbContext context)
        {
            _context = context;
        }

        //Getting Data using store procedure
        public async Task<List<EquipmentInventory>> GetAllAsync()
        {
            try
            {
                var equipmentInventories = await _context.EquipmentInventories
                                             .FromSqlRaw("EXEC [InventoryManagement].[sp_GetAllEquipmentInventories]")
                                             .AsNoTracking()
                                             .ToListAsync();

                return equipmentInventories;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving equipment inventories.", ex);
            }
        }

        //Getting Data using EF Core
        //public async Task<IEnumerable<EquipmentInventory>> GetAllAsync()
        //{
        //    return await _context.EquipmentInventories
        //        .Include(e => e.ItemGroup)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        public async Task<EquipmentInventory?> GetByIdAsync(int id)
        {
            return await _context.EquipmentInventories
                .Include(e => e.ItemGroup)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<EquipmentInventory> AddAsync(EquipmentInventory entity)
        {
            _context.EquipmentInventories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(EquipmentInventory entity)
        {
            _context.EquipmentInventories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.EquipmentInventories.FindAsync(id);
            if (entity != null)
            {
                _context.EquipmentInventories.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
