using PrescriptionManagement.Models;

namespace PrescriptionManagement.Services;

public interface IDbService
{
    Task<Medicament?> GetMedicamentByIdAsync(int id);
    Medicament? GetMedicamentById(int id);
    Task<Patient?> GetPatientByIdAsync(int id);
    Task<Prescription?> GetPrescriptionByIdAsync(int id);
    Task CreatePrescriptionAsync(Prescription prescription);
}