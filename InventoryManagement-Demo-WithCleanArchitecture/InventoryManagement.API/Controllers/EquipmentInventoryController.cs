using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    /// <summary>
    /// API endpoints for EquipmentInventory.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentInventoryController : ControllerBase
    {
        private readonly IEquipmentInventoryService _service;

        public EquipmentInventoryController(IEquipmentInventoryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all equipment inventory items.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EquipmentInventoryResponseDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        /// <summary>
        /// Gets an equipment inventory item by ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EquipmentInventoryResponseDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        /// <summary>
        /// Creates a new equipment inventory item.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EquipmentInventoryResponseDto>> Create([FromBody] EquipmentInventoryRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing equipment inventory item.
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] EquipmentInventoryRequestDto dto)
        {
            try
            {
                await _service.UpdateAsync(id, dto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        /// <summary>
        /// Deletes an equipment inventory item.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
