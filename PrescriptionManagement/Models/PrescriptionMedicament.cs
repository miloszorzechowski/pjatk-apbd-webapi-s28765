using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PrescriptionManagement.Models;

[PrimaryKey(nameof(MedicamentId), nameof(PrescriptionId))]
[Table("Prescription_Medicament")]
public class PrescriptionMedicament
{
    [ForeignKey(nameof(Medicament))]
    public int MedicamentId { get; set; }
    
    [ForeignKey(nameof(Prescription))]
    public int PrescriptionId { get; set; }
    
    public required int Dose { get; set; }
    
    [MaxLength(100)]
    public string? Details { get; set; }
    
    public Prescription Prescription { get; set; }
    public Medicament Medicament { get; set; }
}