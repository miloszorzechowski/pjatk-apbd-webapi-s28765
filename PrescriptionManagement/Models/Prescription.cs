using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionManagement.Models;

[Table("Prescription")]
public class Prescription
{
    public int PrescriptionId { get; set; }
    
    public required DateOnly Date { get; set; }
    
    public required DateOnly DueDate { get; set; }
    
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    
    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
    
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    
    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();
}