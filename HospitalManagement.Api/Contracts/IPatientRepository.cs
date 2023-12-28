using HospitalManagement.Api.Models;

namespace HospitalManagement.Api.Contracts
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<bool> AddPatient(Patient patient);
        Task<bool> UpdatePatient(int id, Patient patient);
        Task<bool> DeletePatient(int id);
    }
}
