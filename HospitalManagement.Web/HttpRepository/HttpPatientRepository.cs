using HospitalManagement.Web.Contracts;
using HospitalManagement.Web.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace HospitalManagement.Web.HttpRepository
{
    public class HttpPatientRepository : IPatient
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HttpPatientRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<bool> AddPatient(Patient patient)
        {
            try
            {
                patient.OrganizationId = 1;
                var response = await _client.PostAsJsonAsync("Patient", patient);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                return true;
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
                var response = await _client.DeleteAsync(_client.BaseAddress + $"Patient/{id}");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                return true;
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
                var response = await _client.GetAsync($"patient/{id}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                var patient = JsonSerializer.Deserialize<Patient>(content, _options);
                return patient;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<Patient>> GetPatients()
        {
            try
            {
                var response = await _client.GetAsync("patient");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                var patients = JsonSerializer.Deserialize<List<Patient>>(content, _options);
                return patients;
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
                var response = await _client.PutAsJsonAsync($"Patient/{id}", patient);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
