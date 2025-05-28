using PrescriptionManagement.DTOs;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Mappers;

public static class PrescriptionMedicamentMapper
{
    public static PrescriptionMedicamentDto ToDto(PrescriptionMedicament prescriptionMedicament)
    {
        return new PrescriptionMedicamentDto
        {
            MedicamentId = prescriptionMedicament.MedicamentId,
            Name = prescriptionMedicament.Medicament.Name,
            Dose = prescriptionMedicament.Dose,
            Details = prescriptionMedicament.Details
        };
    }

    public static PrescriptionMedicament ToEntity(PrescriptionMedicamentDto prescriptionMedicamentDto)
    {
        return new PrescriptionMedicament
        {
            MedicamentId = prescriptionMedicamentDto.MedicamentId,
            Dose = prescriptionMedicamentDto.Dose,
            Details = prescriptionMedicamentDto.Details
        };
    }
    
    public static PrescriptionMedicament ToEntity(CreatePrescriptionMedicamentDto createPrescriptionMedicamentDto)
    {
        return new PrescriptionMedicament
        {
            MedicamentId = createPrescriptionMedicamentDto.MedicamentId,
            Dose = createPrescriptionMedicamentDto.Dose,
            Details = createPrescriptionMedicamentDto.Details
        };
    }
}