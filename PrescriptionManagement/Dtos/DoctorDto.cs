namespace PrescriptionManagement.DTOs;

public class DoctorDto
{
    public required int DoctorId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
}