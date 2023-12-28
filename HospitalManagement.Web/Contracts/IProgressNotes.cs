using HospitalManagement.Web.Models;

namespace HospitalManagement.Web.Contracts
{
    public interface IProgressNotes
    {
        Task<List<ProgressNotes>> GetProgressNoteAsync(int patientId);
        Task<bool> AddProgressNoteAsync(ProgressNotes progressNote);
    }
}
