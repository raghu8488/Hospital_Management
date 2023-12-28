namespace HospitalManagement.Web.Models
{
    public class ProgressNotes
    {
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public DateTime? VisitDate { get; set; }
        public string ProgressText { get; set; }
    }
}
