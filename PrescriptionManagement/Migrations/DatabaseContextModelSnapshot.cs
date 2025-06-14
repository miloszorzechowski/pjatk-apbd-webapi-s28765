﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrescriptionManagement.Data;

#nullable disable

namespace PrescriptionManagement.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PrescriptionManagement.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            DoctorId = -1,
                            Email = "dr.pepper@pepper.com",
                            FirstName = "Dr",
                            LastName = "Pepper"
                        },
                        new
                        {
                            DoctorId = -2,
                            Email = "dr.mundo@riotgames.com",
                            FirstName = "Dr",
                            LastName = "Mundo"
                        });
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Medicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicamentId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MedicamentId");

                    b.ToTable("Medicament");

                    b.HasData(
                        new
                        {
                            MedicamentId = -1,
                            Description = "Used to reduce pain, fever, or inflammation",
                            Name = "Aspirin",
                            Type = "Analgesic"
                        },
                        new
                        {
                            MedicamentId = -2,
                            Description = "Broad-spectrum antibiotic for bacterial infections",
                            Name = "Amoxicillin",
                            Type = "Antibiotic"
                        },
                        new
                        {
                            MedicamentId = -3,
                            Description = "Relieves allergy symptoms such as itching and runny nose",
                            Name = "Cetirizine",
                            Type = "Antihistamine"
                        },
                        new
                        {
                            MedicamentId = -4,
                            Description = "Selective serotonin reuptake inhibitor for depression and anxiety",
                            Name = "Sertraline",
                            Type = "Antidepressant"
                        },
                        new
                        {
                            MedicamentId = -5,
                            Description = "Used to treat high blood pressure and heart failure",
                            Name = "Lisinopril",
                            Type = "Antihypertensive"
                        },
                        new
                        {
                            MedicamentId = -6,
                            Description = "Helps control blood sugar levels in type 2 diabetes",
                            Name = "Metformin",
                            Type = "Antidiabetic"
                        },
                        new
                        {
                            MedicamentId = -7,
                            Description = "Anticoagulant used to prevent blood clots",
                            Name = "Warfarin",
                            Type = "Anticoagulant"
                        },
                        new
                        {
                            MedicamentId = -8,
                            Description = "Antiviral medication for influenza treatment and prevention",
                            Name = "Oseltamivir",
                            Type = "Antiviral"
                        },
                        new
                        {
                            MedicamentId = -9,
                            Description = "Treats fungal infections such as candidiasis",
                            Name = "Fluconazole",
                            Type = "Antifungal"
                        },
                        new
                        {
                            MedicamentId = -10,
                            Description = "Provides active immunity against hepatitis B virus",
                            Name = "Hepatitis B Vaccine",
                            Type = "Vaccine"
                        },
                        new
                        {
                            MedicamentId = -11,
                            Description = "Used to treat anxiety, muscle spasms, and seizures",
                            Name = "Diazepam",
                            Type = "Sedative"
                        });
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PatientId");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            PatientId = -1,
                            Birthdate = new DateOnly(2003, 2, 21),
                            FirstName = "John",
                            LastName = "Jinx"
                        },
                        new
                        {
                            PatientId = -2,
                            Birthdate = new DateOnly(2003, 6, 10),
                            FirstName = "Tristana",
                            LastName = "Swain"
                        });
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Prescription", b =>
                {
                    b.Property<int>("PrescriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrescriptionId"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("PrescriptionId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Prescription");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("MedicamentId")
                        .HasColumnType("int");

                    b.Property<int>("PrescriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Dose")
                        .HasColumnType("int");

                    b.HasKey("MedicamentId", "PrescriptionId");

                    b.HasIndex("PrescriptionId");

                    b.ToTable("Prescription_Medicament");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Prescription", b =>
                {
                    b.HasOne("PrescriptionManagement.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrescriptionManagement.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("PrescriptionManagement.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("MedicamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrescriptionManagement.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionMedicaments")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("PrescriptionManagement.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}
