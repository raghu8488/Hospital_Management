using HospitalManagement.Web.Contracts;
using HospitalManagement.Web.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace HospitalManagement.Web.HttpRepository
{
    public class HttpProgressNotesRepository : IProgressNotes
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public HttpProgressNotesRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<bool> AddProgressNoteAsync(ProgressNotes progressNote)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("ProgressNotes", progressNote);
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ProgressNotes>> GetProgressNoteAsync(int patientId)
        {
            try
            {
                var response = await _client.GetAsync($"ProgressNotes/{patientId}");
                var content = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }
                var progressNotes = JsonSerializer.Deserialize<List<ProgressNotes>>(content, _options);
                return progressNotes;
            }
            catch { throw; }
            }
    }
}
