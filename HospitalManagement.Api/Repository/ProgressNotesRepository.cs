using HospitalManagement.Api.Contracts;
using HospitalManagement.Api.Data;
using HospitalManagement.Api.Models;

namespace HospitalManagement.Api.Repository
{
    public class ProgressNotesRepository : IProgressNotesRepository
    {
        private readonly DataContext _dataContext;

        public ProgressNotesRepository(DataContext dataContext)
        {
            _dataContext = dataContext;

        }
        public async Task<bool> AddProgressNote(ProgressNotes progressNote)
        {
            try
            {
                await _dataContext.ProgressNotes.AddAsync(progressNote);
                return (_dataContext.SaveChanges() > 0 ? true : false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProgressNotes>> GetProgressNotes(int patientId)
        {
            try
            {
                var progressNotes = _dataContext.ProgressNotes.Where(x => x.PatientId == patientId).ToList();
                return progressNotes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
