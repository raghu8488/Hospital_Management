using HospitalManagement.Api.Contracts;
using HospitalManagement.Api.Data;
using HospitalManagement.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Api.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _dataContext;

        public PatientRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> AddPatient(Patient patient)
        {
            try
            {
                patient.CreatedAt = DateTime.Now;
               await _dataContext.Patients.AddAsync(patient);
                return (await _dataContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletePatient(int id)
        {
            try
            {
                var patient = await _dataContext.Patients.FindAsync(id);
                if (patient != null)
                {
                    patient.IsDeleted = true;
                    patient.UpdatedAt = DateTime.Now;
                    return (await _dataContext.SaveChangesAsync() > 0 ? true : false);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Patient> GetPatient(int id)
        {
            try
            {
                var patient = await _dataContext.Patients.FindAsync(id);
                return patient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            try
            {
                var patient = await _dataContext.Patients.Where(x => x.IsDeleted == false).ToListAsync();
                return patient;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdatePatient(int id, Patient patient)
        {
            try
            {
                var existingPatient = await _dataContext.Patients.FindAsync(id);

                if (existingPatient == null)
                {
                    throw new ArgumentException("Patient not found");
                }

                // Update the properties of the existing patient
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.Address = patient.Address;
                existingPatient.State = patient.State;
                existingPatient.City = patient.City;
                existingPatient.OrganizationId = patient.OrganizationId;
                existingPatient.UpdatedAt = DateTime.Now; // Update the 'UpdatedAt' property

                return (await _dataContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
