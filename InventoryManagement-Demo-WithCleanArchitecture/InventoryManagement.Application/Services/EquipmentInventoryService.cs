using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Interfaces;

namespace InventoryManagement.Application.Services
{
    public class EquipmentInventoryService : IEquipmentInventoryService
    {
        private readonly IEquipmentInventoryRepository _repository;

        public EquipmentInventoryService(IEquipmentInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EquipmentInventoryResponseDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(MapToResponseDto);
        }

        public async Task<EquipmentInventoryResponseDto?> GetByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : MapToResponseDto(item);
        }

        public async Task<EquipmentInventoryResponseDto> CreateAsync(EquipmentInventoryRequestDto dto)
        {
            var entity = new EquipmentInventory
            {
                ItemCode = dto.ItemCode,
                ItemName = dto.ItemName,
                Make = dto.Make,
                ItemModel = dto.ItemModel,
                TrackingMethod = dto.TrackingMethod,
                ItemGroupId = dto.ItemGroupId,
                IsVoid = dto.IsVoid
            };

            var created = await _repository.AddAsync(entity);
            // Fetch with ItemGroup for response
            var result = await _repository.GetByIdAsync(created.Id);
            return MapToResponseDto(result!);
        }

        public async Task UpdateAsync(int id, EquipmentInventoryRequestDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"EquipmentInventory with Id {id} not found.");

            entity.ItemCode = dto.ItemCode;
            entity.ItemName = dto.ItemName;
            entity.Make = dto.Make;
            entity.ItemModel = dto.ItemModel;
            entity.TrackingMethod = dto.TrackingMethod;
            entity.ItemGroupId = dto.ItemGroupId;
            entity.IsVoid = dto.IsVoid;

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"EquipmentInventory with Id {id} not found.");

            await _repository.DeleteAsync(id);
        }

        private static EquipmentInventoryResponseDto MapToResponseDto(EquipmentInventory entity)
        {
            return new EquipmentInventoryResponseDto
            {
                Id = entity.Id,
                ItemCode = entity.ItemCode,
                ItemName = entity.ItemName,
                Make = entity.Make,
                ItemModel = entity.ItemModel,
                TrackingMethod = entity.TrackingMethod,
                ItemGroupId = entity.ItemGroupId,
                ItemGroupName = entity.ItemGroup?.ItemGroupName ?? string.Empty,
                IsVoid = entity.IsVoid
            };
        }
    }
}
