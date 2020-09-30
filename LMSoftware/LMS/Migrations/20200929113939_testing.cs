using Microsoft.EntityFrameworkCore.Migrations;

namespace LMS.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Tests_PatientTestTestId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Physicians_PhysicianId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PatientTestTestId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PhysicianId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientTestTestId",
                table: "Patients");

            migrationBuilder.AddColumn<int>(
                name: "patientsId",
                table: "Tests",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhysicianId",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "physicianId",
                table: "Appointments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_patientsId",
                table: "Tests",
                column: "patientsId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhysicianId",
                table: "Patients",
                column: "PhysicianId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_physicianId",
                table: "Appointments",
                column: "physicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Physicians_physicianId",
                table: "Appointments",
                column: "physicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Physicians_PhysicianId",
                table: "Patients",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Patients_patientsId",
                table: "Tests",
                column: "patientsId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Physicians_physicianId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Physicians_PhysicianId",
                table: "Patients");

            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Patients_patientsId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_patientsId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Patients_PhysicianId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_physicianId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "patientsId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "physicianId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "PhysicianId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PatientTestTestId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PatientTestTestId",
                table: "Patients",
                column: "PatientTestTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_PhysicianId",
                table: "Patients",
                column: "PhysicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Tests_PatientTestTestId",
                table: "Patients",
                column: "PatientTestTestId",
                principalTable: "Tests",
                principalColumn: "TestId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Physicians_PhysicianId",
                table: "Patients",
                column: "PhysicianId",
                principalTable: "Physicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
