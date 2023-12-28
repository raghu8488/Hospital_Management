using HospitalManagement.Api.Contracts;
using HospitalManagement.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var patients = await _patientRepository.GetPatients();
                return Ok(patients);
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatient(id);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            try
            {
                await _patientRepository.AddPatient(patient);
                return CreatedAtAction(nameof(Get), new { id = patient.PatientId }, patient);
                
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create patient: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            try
            {
                return Ok(await _patientRepository.UpdatePatient(id, patient));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _patientRepository.DeletePatient(id));
            }
            catch
            {
                throw;
            }
        }
    }
}
