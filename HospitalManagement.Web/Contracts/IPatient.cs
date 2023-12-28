using HospitalManagement.Web.Models;

namespace HospitalManagement.Web.Contracts
{
    public interface IPatient
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatient(int id);
        Task<bool> AddPatient(Patient patient);
        Task<bool> UpdatePatient(int id, Patient patient);
        Task<bool> DeletePatient(int id);
    }
}
