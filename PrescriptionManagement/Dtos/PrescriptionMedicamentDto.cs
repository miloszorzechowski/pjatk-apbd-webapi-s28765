namespace PrescriptionManagement.DTOs;

public class PrescriptionMedicamentDto
{
    public required int MedicamentId { get; set; }
    public required string Name { get; set; }
    public required int Dose { get; set; }
    public string? Details { get; set; }
}