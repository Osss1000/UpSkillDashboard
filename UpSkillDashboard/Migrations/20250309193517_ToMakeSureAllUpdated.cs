using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class ToMakeSureAllUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatusEnum",
                table: "ApplicationStatuses");

            migrationBuilder.AddColumn<bool>(
                name: "IsManuallyClosed",
                table: "PaidJobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ApplicationStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManuallyClosed",
                table: "PaidJobs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ApplicationStatuses");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatusEnum",
                table: "ApplicationStatuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
