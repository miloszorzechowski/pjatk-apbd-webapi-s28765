namespace PrescriptionManagement.DTOs;

public class PrescriptionDto
{
    public required int PrescriptionId { get; set; }
    
    public required DateOnly Date { get; set; }
    
    public required DateOnly DueDate { get; set; }
    
    public required DoctorDto Doctor { get; set; }
    
    public required PatientDto Patient { get; set; }
    
    public required ICollection<PrescriptionMedicamentDto> Medicaments { get; set; } = new List<PrescriptionMedicamentDto>();
}