using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recepty.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date{ get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public virtual ICollection<Prescription_Medicament> Prescriptions_Medicament { get; set; }
        [ForeignKey("IdPatient")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor Doctor { get; set; }
    }
}
