namespace PrescriptionManagement.DTOs;

public class PatientWithPrescriptionsDto
{
    public required int PatientId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly Birthdate { get; set; }
    public required ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
}