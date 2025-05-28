using Microsoft.EntityFrameworkCore;
using PrescriptionManagement.Models;

namespace PrescriptionManagement.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new() { DoctorId = -1, FirstName = "Dr", LastName = "Pepper", Email = "dr.pepper@pepper.com" },
            new() { DoctorId = -2, FirstName = "Dr", LastName = "Mundo", Email = "dr.mundo@riotgames.com" },
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new() { MedicamentId = -1, Name = "Aspirin", Description = "Used to reduce pain, fever, or inflammation", Type = "Analgesic" },
            new() { MedicamentId = -2, Name = "Amoxicillin", Description = "Broad-spectrum antibiotic for bacterial infections", Type = "Antibiotic" },
            new() { MedicamentId = -3, Name = "Cetirizine", Description = "Relieves allergy symptoms such as itching and runny nose", Type = "Antihistamine" },
            new() { MedicamentId = -4, Name = "Sertraline", Description = "Selective serotonin reuptake inhibitor for depression and anxiety", Type = "Antidepressant" },
            new() { MedicamentId = -5, Name = "Lisinopril", Description = "Used to treat high blood pressure and heart failure", Type = "Antihypertensive" },
            new() { MedicamentId = -6, Name = "Metformin", Description = "Helps control blood sugar levels in type 2 diabetes", Type = "Antidiabetic" },
            new() { MedicamentId = -7, Name = "Warfarin", Description = "Anticoagulant used to prevent blood clots", Type = "Anticoagulant" },
            new() { MedicamentId = -8, Name = "Oseltamivir", Description = "Antiviral medication for influenza treatment and prevention", Type = "Antiviral" },
            new() { MedicamentId = -9, Name = "Fluconazole", Description = "Treats fungal infections such as candidiasis", Type = "Antifungal" },
            new() { MedicamentId = -10, Name = "Hepatitis B Vaccine", Description = "Provides active immunity against hepatitis B virus", Type = "Vaccine" },
            new() { MedicamentId = -11, Name = "Diazepam", Description = "Used to treat anxiety, muscle spasms, and seizures", Type = "Sedative" }
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new() { PatientId = -1, FirstName = "John", LastName = "Jinx", Birthdate = new DateOnly(2003, 2, 21) },
            new() { PatientId = -2, FirstName = "Tristana", LastName = "Swain", Birthdate = new DateOnly(2003, 6, 10) }
        });
    }
}