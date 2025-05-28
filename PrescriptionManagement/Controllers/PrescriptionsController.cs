using Microsoft.AspNetCore.Mvc;
using PrescriptionManagement.DTOs;
using PrescriptionManagement.Mappers;
using PrescriptionManagement.Models;
using PrescriptionManagement.Services;

namespace PrescriptionManagement.Controllers;

[ApiController]
[Route("[controller]")]
public class PrescriptionsController(IDbService dbService)
    : ControllerBase
{
    private const int MaxMedicamentsCount = 10;

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PrescriptionDto>> GetById(int id)
    {
        var prescription = await dbService.GetPrescriptionByIdAsync(id);
        
        if (prescription == null)
        {
            return NotFound($"Prescription with ID {id} not found");
        }
        
        return Ok(PrescriptionMapper.ToDto(prescription));
    }
    
    [HttpPost]
    public async Task<ActionResult<PrescriptionDto>> CreatePrescriptionAsync([FromBody] CreatePrescriptionDto dto)
    {
        if (dto.Date > dto.DueDate)
        {
            return BadRequest("Due date must be greater or equal than date");
        }
        
        switch (dto.Medicaments.Count)
        {
            case > MaxMedicamentsCount:
                return BadRequest($"Prescription can contain maximum {MaxMedicamentsCount} medicaments");
            case 0:
                return BadRequest("No medicaments provided");
        }

        var patientEntity = await dbService.GetPatientByIdAsync(dto.Patient.PatientId) 
                            ?? PatientMapper.ToEntity(dto.Patient);


        var medicamentIds = dto.Medicaments
            .Select(med => med.MedicamentId)
            .ToList();
        
        var uniqueItems = new HashSet<int>();
        var duplicates = medicamentIds.Where(id => !uniqueItems.Add(id))
            .Distinct()
            .ToList();
        
        duplicates.Sort();
        
        if (duplicates.Count != 0)
        {
            return BadRequest($"Duplicate medicament IDs: {string.Join(", ", duplicates)}");
        }
        
        var medicaments = medicamentIds.Select(dbService.GetMedicamentById);

        var unknownMedicamentsIds = medicamentIds
            .Zip(medicaments, (id, med) => new { id, med })
            .TakeWhile(pair => pair.med == null)
            .Select(pair => pair.id)
            .ToList();
        
        unknownMedicamentsIds.Sort();
        
        if (unknownMedicamentsIds.Count != 0)
        {
            return BadRequest($"Unknown medicaments with IDs: {string.Join(", ", unknownMedicamentsIds)}");
        }

        var prescriptionEntity = new Prescription
        {
            Date = dto.Date,
            DueDate = dto.DueDate,
            DoctorId = dto.DoctorId,
            Patient = patientEntity,
            PrescriptionMedicaments = dto.Medicaments.Select(PrescriptionMedicamentMapper.ToEntity).ToList()
        };
        
        await dbService.CreatePrescriptionAsync(prescriptionEntity);
        
        dto.PrescriptionId = prescriptionEntity.PrescriptionId;

        return CreatedAtAction(
            nameof(GetById),
            new { id = dto.PrescriptionId },
            dto
        );
    }
}