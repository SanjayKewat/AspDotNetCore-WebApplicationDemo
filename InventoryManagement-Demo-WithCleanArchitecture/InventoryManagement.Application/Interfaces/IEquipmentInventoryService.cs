using InventoryManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Interfaces
{
    public interface IEquipmentInventoryService
    {
        Task<IEnumerable<EquipmentInventoryResponseDto>> GetAllAsync();
        Task<EquipmentInventoryResponseDto?> GetByIdAsync(int id);
        Task<EquipmentInventoryResponseDto> CreateAsync(EquipmentInventoryRequestDto dto);
        Task UpdateAsync(int id, EquipmentInventoryRequestDto dto);
        Task DeleteAsync(int id);
    }
}
