using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionManagement.Models;

[Table("Medicament")]
public class Medicament
{
    public int MedicamentId { get; set; }
    
    [MaxLength(100)]
    public required string Name { get; set; }
    
    [MaxLength(100)]
    public required string Description { get; set; }
    
    [MaxLength(100)]
    public required string Type { get; set; }
    
    public ICollection<PrescriptionMedicament>? PrescriptionMedicaments { get; set; }
}