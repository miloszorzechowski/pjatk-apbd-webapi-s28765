using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrescriptionManagement.Models;

[Table("Doctor")]
public class Doctor
{
    public int DoctorId { get; set; }
    
    [MaxLength(100)]
    public required string FirstName { get; set; }
    
    [MaxLength(100)]
    public required string LastName { get; set; }
    
    [MaxLength(100)]
    public required string Email { get; set; }
    
    public ICollection<Prescription>? Prescriptions { get; set; }
}