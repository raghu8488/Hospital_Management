using HospitalManagement.Api.Contracts;
using HospitalManagement.Api.Models;
using HospitalManagement.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProgressNotesController : ControllerBase
    {
        private readonly IProgressNotesRepository _progressNotesRepository;

        public ProgressNotesController(IProgressNotesRepository progressNotesRepository)
        {
            _progressNotesRepository = progressNotesRepository;
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetAll(int patientId)
        {
            try
            {
                var progNotes = await _progressNotesRepository.GetProgressNotes(patientId);
                return Ok(progNotes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProgressNotes progressNotes)
        {
            try
            {
                await _progressNotesRepository.AddProgressNote(progressNotes);
                return Ok(true);

            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create notes: {ex.Message}");
            }
        }

    }
}
