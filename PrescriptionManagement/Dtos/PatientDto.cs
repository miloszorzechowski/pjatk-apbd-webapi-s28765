namespace PrescriptionManagement.DTOs;

public class PatientDto
{
    public int PatientId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required DateOnly Birthdate { get; set; }
}