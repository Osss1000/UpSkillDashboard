using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientPostModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ClientPosts",
                type: "nvarchar(2550)",
                maxLength: 2550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ClientPosts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientPosts_UserId",
                table: "ClientPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPosts_Users_UserId",
                table: "ClientPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPosts_Users_UserId",
                table: "ClientPosts");

            migrationBuilder.DropIndex(
                name: "IX_ClientPosts_UserId",
                table: "ClientPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClientPosts");

            migrationBuilder.AlterColumn<string>(
                name: "Details",
                table: "ClientPosts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2550)",
                oldMaxLength: 2550,
                oldNullable: true);
        }
    }
}
