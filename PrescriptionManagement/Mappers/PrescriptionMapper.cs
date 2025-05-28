using PrescriptionManagement.DTOs;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Mappers;

public static class PrescriptionMapper
{
    public static PrescriptionDto ToDto(Prescription prescription)
    {
        return new PrescriptionDto
        {
            PrescriptionId = prescription.PrescriptionId,
            Date = prescription.Date,
            DueDate = prescription.DueDate,
            Doctor = DoctorMapper.ToDto(prescription.Doctor),
            Patient = PatientMapper.ToDto(prescription.Patient),
            Medicaments = prescription.PrescriptionMedicaments
                .Select(PrescriptionMedicamentMapper.ToDto)
                .ToList()
        };
    }

    public static Prescription ToEntity(PrescriptionDto prescriptionDto)
    {
        return new Prescription
        {
            Date = prescriptionDto.Date,
            DueDate = prescriptionDto.DueDate,
            PrescriptionId = prescriptionDto.PrescriptionId,
            PatientId = prescriptionDto.Patient.PatientId,
            DoctorId = prescriptionDto.Doctor.DoctorId,
            Patient = PatientMapper.ToEntity(prescriptionDto.Patient),
            Doctor = DoctorMapper.ToEntity(prescriptionDto.Doctor),
            PrescriptionMedicaments = prescriptionDto.Medicaments
                .Select(PrescriptionMedicamentMapper.ToEntity)
                .ToList()
        };
    }
}