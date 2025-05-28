using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionManagement.Models;

[Table("Patient")]
public class Patient
{
    public int PatientId { get; set; }
    
    [MaxLength(100)]
    public required string FirstName { get; set; }
    
    [MaxLength(100)]
    public required string LastName { get; set; }
    
    public required DateOnly Birthdate { get; set; }
    
    public ICollection<Prescription>? Prescriptions { get; set; }
}