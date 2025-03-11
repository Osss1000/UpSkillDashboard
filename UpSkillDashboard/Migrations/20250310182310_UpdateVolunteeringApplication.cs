using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVolunteeringApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "VolunteeringApplications");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicantType",
                table: "VolunteeringApplications",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "VolunteeringApplications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkerId",
                table: "VolunteeringApplications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringApplications_ClientId",
                table: "VolunteeringApplications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteeringApplications_WorkerId",
                table: "VolunteeringApplications",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplications_Clients_ClientId",
                table: "VolunteeringApplications",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplications_Workers_WorkerId",
                table: "VolunteeringApplications",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplications_Clients_ClientId",
                table: "VolunteeringApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplications_Workers_WorkerId",
                table: "VolunteeringApplications");

            migrationBuilder.DropIndex(
                name: "IX_VolunteeringApplications_ClientId",
                table: "VolunteeringApplications");

            migrationBuilder.DropIndex(
                name: "IX_VolunteeringApplications_WorkerId",
                table: "VolunteeringApplications");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "VolunteeringApplications");

            migrationBuilder.DropColumn(
                name: "WorkerId",
                table: "VolunteeringApplications");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantType",
                table: "VolunteeringApplications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ApplicantId",
                table: "VolunteeringApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
