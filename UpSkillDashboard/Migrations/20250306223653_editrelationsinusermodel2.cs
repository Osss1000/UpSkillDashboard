using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class editrelationsinusermodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Workers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HourlyRate",
                table: "Workers",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");
        }
    }
}
