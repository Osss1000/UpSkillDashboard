using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class editrelationsinusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Workers_UserId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Clients_UserId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_UserId",
                table: "Workers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_UserId",
                table: "Organizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");
        }
    }
}
