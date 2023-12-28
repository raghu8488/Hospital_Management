using HospitalManagement.Api.Models;

namespace HospitalManagement.Api.Contracts
{
    public interface IProgressNotesRepository
    {
        Task<List<ProgressNotes>> GetProgressNotes(int patientId);
        Task<bool> AddProgressNote(ProgressNotes progressNote);
    }
}
