﻿using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Api.Models
{
    public class ProgressNotes
    {
        [Key]
        public int VisitId { get; set; }
        public int PatientId { get; set; }
        public DateTime? VisitDate { get; set; }
        public string ProgressText {  get; set; }


    }
}
