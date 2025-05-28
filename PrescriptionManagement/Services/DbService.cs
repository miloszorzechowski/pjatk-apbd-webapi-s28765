using Microsoft.EntityFrameworkCore;
using PrescriptionManagement.Data;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Services;

public class DbService(DatabaseContext context) : IDbService
{
    public async Task<Medicament?> GetMedicamentByIdAsync(int id)
    {
        return await context.Medicaments.FindAsync(id);
    }
    
    public Medicament? GetMedicamentById(int id)
    {
        return context.Medicaments.Find(id);
    }
    
    public async Task CreatePrescriptionAsync(Prescription prescription)
    {
        await context.Prescriptions.AddAsync(prescription);
        await context.SaveChangesAsync();
    }

    public async Task<Prescription?> GetPrescriptionByIdAsync(int id)
    {
        return await context.Prescriptions
            .Include(p => p.Doctor)
            .Include(p => p.Patient)
            .Include(p => p.PrescriptionMedicaments)
                .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.PrescriptionId == id);
    }
    
    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await context.Patients
            .Include(p => p.Prescriptions!)
                .ThenInclude(pres => pres.Doctor)
            .Include(p => p.Prescriptions!)
                .ThenInclude(pres => pres.PrescriptionMedicaments)
                    .ThenInclude(pm => pm.Medicament)
            .FirstOrDefaultAsync(p => p.PatientId == id);
    }
}