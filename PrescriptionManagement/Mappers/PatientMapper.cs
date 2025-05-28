using PrescriptionManagement.DTOs;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Mappers;

public static class PatientMapper
{
    public static PatientDto ToDto(Patient patient)
    {
        return new PatientDto
        {
            PatientId = patient.PatientId,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Birthdate = patient.Birthdate
        };
    }

    public static Patient ToEntity(PatientDto patientDto)
    {
        return new Patient
        {
            PatientId = patientDto.PatientId,
            FirstName = patientDto.FirstName,
            LastName = patientDto.LastName,
            Birthdate = patientDto.Birthdate
        };
    }
}