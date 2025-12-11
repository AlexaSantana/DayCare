using DayCare.Application.DTOs;
using DayCare.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DayCare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorsController : ControllerBase
    {
        private readonly ITutorService _tutorService;

        public TutorsController(ITutorService tutorService)
        {
            _tutorService = tutorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TutorDto>>> GetAll()
        {
            var tutors = await _tutorService.GetAllAsync();
            return Ok(tutors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TutorDto>> GetById(int id)
        {
            var tutor = await _tutorService.GetByIdAsync(id);
            if (tutor == null)
                return NotFound();

            return Ok(tutor);
        }

        [HttpPost]
        public async Task<ActionResult<TutorDto>> Create([FromBody] CreateTutorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _tutorService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTutorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _tutorService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _tutorService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
