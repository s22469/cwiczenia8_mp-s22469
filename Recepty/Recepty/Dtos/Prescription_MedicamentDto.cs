using System.ComponentModel.DataAnnotations.Schema;

namespace Recepty.Dtos
{
    public class Prescription_MedicamentDto
    {
        public virtual MedicamentDto Medicament { get; set; }
    }
}
