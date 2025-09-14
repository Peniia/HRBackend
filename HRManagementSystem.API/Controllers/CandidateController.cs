using HRManagementSystem.Application.Candidate.DTOs;
using HRManagementSystem.Application.Services;
using HRManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "HRManager")]
    public class CandidateController : ControllerBase
    {
        private readonly CandidateService _candidateService;
        public CandidateController(CandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CandidateDto>>> GetAll()
        {
            var data = await _candidateService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CandidateDto>> GetById(int id)
        {
            var data = await _candidateService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateCandidateDto dto)
        {
            var id = await _candidateService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCandidateDto dto)
        {
            var result = await _candidateService.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _candidateService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            var result = await _candidateService.UpdateStatusAsync(id, status);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/note")]
        public async Task<IActionResult> AddNote(int id, [FromBody] string note)
        {
            var result = await _candidateService.AddNoteAsync(id, note);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}