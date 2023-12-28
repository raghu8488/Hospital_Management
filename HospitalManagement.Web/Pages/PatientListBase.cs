using HospitalManagement.Web.Contracts;
using HospitalManagement.Web.Models;
using Microsoft.AspNetCore.Components;

namespace HospitalManagement.Web.Pages
{
    public partial class PatientListBase : ComponentBase
    {
        [Parameter]
        public int OrganizationId { get; set; } = 0;

        [Parameter]
        public List<Patient> patientList { get; set; } = new List<Patient>();
        [Inject]
        public IPatient PatientRepo { get; set; }
        protected async override Task OnInitializedAsync()
        {
            patientList = await PatientRepo.GetPatients();
        }

    }
}
