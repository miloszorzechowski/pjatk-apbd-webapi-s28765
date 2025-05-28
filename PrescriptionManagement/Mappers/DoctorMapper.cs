using PrescriptionManagement.DTOs;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Mappers;

public static class DoctorMapper
{
    public static DoctorDto ToDto(Doctor doctor)
    {
        return new DoctorDto
        {
            DoctorId = doctor.DoctorId,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Email = doctor.Email
        };
    }
    
    public static Doctor ToEntity(DoctorDto doctorDto)
    {
        return new Doctor
        {
            DoctorId = doctorDto.DoctorId,
            FirstName = doctorDto.FirstName,
            LastName = doctorDto.LastName,
            Email = doctorDto.Email
        };
    }
}