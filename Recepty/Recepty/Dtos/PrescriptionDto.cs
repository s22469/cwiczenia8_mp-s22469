using Recepty.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepty.Dtos
{
    public class PrescriptionDto
    {
        public virtual PatientDto Patient { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual DoctorDto Doctor { get; set; }
        public virtual ICollection<Prescription_MedicamentDto> Medicaments { get; set; }
    }
}