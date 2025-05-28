using Microsoft.AspNetCore.Mvc;
using PrescriptionManagement.DTOs;
using PrescriptionManagement.Mappers;
using PrescriptionManagement.Services;

namespace PrescriptionManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController(IDbService dbService) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<PatientWithPrescriptionsDto>> GetById(int id)
    {
        var patientEntity = await dbService.GetPatientByIdAsync(id);

        if (patientEntity == null)
        {
            return NotFound("Patient not found");
        }
        
        var patientDto = new PatientWithPrescriptionsDto
        {
            PatientId = patientEntity.PatientId,
            FirstName = patientEntity.FirstName,
            LastName = patientEntity.LastName,
            Birthdate = patientEntity.Birthdate,
            Prescriptions = patientEntity.Prescriptions?.Select(PrescriptionMapper.ToDto).ToList() ?? []
        };
        
        return Ok(patientDto);
    }
}