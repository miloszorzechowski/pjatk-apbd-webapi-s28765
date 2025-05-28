namespace PrescriptionManagement.DTOs;

public class CreatePrescriptionDto
{
    public int PrescriptionId { get; set; }

    public required PatientDto Patient { get; set; } = null!;
    
    public ICollection<CreatePrescriptionMedicamentDto> Medicaments { get; set; } = new List<CreatePrescriptionMedicamentDto>();

    public required DateOnly Date { get; set; }
    
    public required DateOnly DueDate { get; set; }
    
    public required int DoctorId { get; set; }
}

public class CreatePrescriptionMedicamentDto
{
    public required int MedicamentId { get; set; }
    
    public required int Dose { get; set; }
    
    public required string Details { get; set; }
}