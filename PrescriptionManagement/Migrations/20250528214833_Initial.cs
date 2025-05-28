using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrescriptionManagement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    MedicamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicament", x => x.MedicamentId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    PrescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.PrescriptionId);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription_Medicament",
                columns: table => new
                {
                    MedicamentId = table.Column<int>(type: "int", nullable: false),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    Dose = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription_Medicament", x => new { x.MedicamentId, x.PrescriptionId });
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Medicament_MedicamentId",
                        column: x => x.MedicamentId,
                        principalTable: "Medicament",
                        principalColumn: "MedicamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prescription_Medicament_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "PrescriptionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "DoctorId", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -2, "dr.mundo@riotgames.com", "Dr", "Mundo" },
                    { -1, "dr.pepper@pepper.com", "Dr", "Pepper" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "MedicamentId", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { -11, "Used to treat anxiety, muscle spasms, and seizures", "Diazepam", "Sedative" },
                    { -10, "Provides active immunity against hepatitis B virus", "Hepatitis B Vaccine", "Vaccine" },
                    { -9, "Treats fungal infections such as candidiasis", "Fluconazole", "Antifungal" },
                    { -8, "Antiviral medication for influenza treatment and prevention", "Oseltamivir", "Antiviral" },
                    { -7, "Anticoagulant used to prevent blood clots", "Warfarin", "Anticoagulant" },
                    { -6, "Helps control blood sugar levels in type 2 diabetes", "Metformin", "Antidiabetic" },
                    { -5, "Used to treat high blood pressure and heart failure", "Lisinopril", "Antihypertensive" },
                    { -4, "Selective serotonin reuptake inhibitor for depression and anxiety", "Sertraline", "Antidepressant" },
                    { -3, "Relieves allergy symptoms such as itching and runny nose", "Cetirizine", "Antihistamine" },
                    { -2, "Broad-spectrum antibiotic for bacterial infections", "Amoxicillin", "Antibiotic" },
                    { -1, "Used to reduce pain, fever, or inflammation", "Aspirin", "Analgesic" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "PatientId", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { -2, new DateOnly(2003, 6, 10), "Tristana", "Swain" },
                    { -1, new DateOnly(2003, 2, 21), "John", "Jinx" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_DoctorId",
                table: "Prescription",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_PatientId",
                table: "Prescription",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Medicament_PrescriptionId",
                table: "Prescription_Medicament",
                column: "PrescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prescription_Medicament");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
