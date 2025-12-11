using DayCare.Application.DTOs;
using DayCare.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChildrenController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildrenController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChildDto>>> GetAll()
        {
            var children = await _childService.GetAllAsync();
            return Ok(children);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChildDto>> GetById(int id)
        {
            var child = await _childService.GetByIdAsync(id);
            if (child == null)
                return NotFound();

            return Ok(child);
        }

        [HttpPost]
        public async Task<ActionResult<ChildDto>> Create([FromBody] CreateChildDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _childService.CreateAsync(dto);

            if (created == null)
                return BadRequest("El tutor especificado no existe.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateChildDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _childService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _childService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
