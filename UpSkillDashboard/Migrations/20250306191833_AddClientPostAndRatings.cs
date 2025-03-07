using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class AddClientPostAndRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPost_Clients_ClientId",
                table: "ClientPost");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidJob_Organizations_OrganizationId",
                table: "PaidJob");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplication_ApplicationStatuses_ApplicationStatusId",
                table: "VolunteeringApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplication_VolunteeringJobs_VolunteeringJobId",
                table: "VolunteeringApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplication_ApplicationStatuses_ApplicationStatusId",
                table: "WorkerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplication_ClientPost_ClientPostId",
                table: "WorkerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplication_PaidJob_PaidJobId",
                table: "WorkerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplication_Workers_WorkerId",
                table: "WorkerApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerApplication",
                table: "WorkerApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteeringApplication",
                table: "VolunteeringApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaidJob",
                table: "PaidJob");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientPost",
                table: "ClientPost");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "WorkerApplication",
                newName: "WorkerApplications");

            migrationBuilder.RenameTable(
                name: "VolunteeringApplication",
                newName: "VolunteeringApplications");

            migrationBuilder.RenameTable(
                name: "PaidJob",
                newName: "PaidJobs");

            migrationBuilder.RenameTable(
                name: "ClientPost",
                newName: "ClientPosts");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplication_WorkerId",
                table: "WorkerApplications",
                newName: "IX_WorkerApplications_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplication_PaidJobId",
                table: "WorkerApplications",
                newName: "IX_WorkerApplications_PaidJobId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplication_ClientPostId",
                table: "WorkerApplications",
                newName: "IX_WorkerApplications_ClientPostId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplication_ApplicationStatusId",
                table: "WorkerApplications",
                newName: "IX_WorkerApplications_ApplicationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteeringApplication_VolunteeringJobId",
                table: "VolunteeringApplications",
                newName: "IX_VolunteeringApplications_VolunteeringJobId");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteeringApplication_ApplicationStatusId",
                table: "VolunteeringApplications",
                newName: "IX_VolunteeringApplications_ApplicationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidJob_OrganizationId",
                table: "PaidJobs",
                newName: "IX_PaidJobs_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPost_ClientId",
                table: "ClientPosts",
                newName: "IX_ClientPosts_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerApplications",
                table: "WorkerApplications",
                column: "WorkerApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteeringApplications",
                table: "VolunteeringApplications",
                column: "VolunteeringApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaidJobs",
                table: "PaidJobs",
                column: "PaidJobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientPosts",
                table: "ClientPosts",
                column: "ClientPostId");

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Ratings_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "WorkerId");
                });

            migrationBuilder.CreateTable(
                name: "Sponsors",
                columns: table => new
                {
                    SponsorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sponsors", x => x.SponsorId);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SponsorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_Advertisements_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "SponsorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_SponsorId",
                table: "Advertisements",
                column: "SponsorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ClientId",
                table: "Ratings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_WorkerId",
                table: "Ratings",
                column: "WorkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPosts_Clients_ClientId",
                table: "ClientPosts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UserId",
                table: "Organizations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaidJobs_Organizations_OrganizationId",
                table: "PaidJobs",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplications_ApplicationStatuses_ApplicationStatusId",
                table: "VolunteeringApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplications_VolunteeringJobs_VolunteeringJobId",
                table: "VolunteeringApplications",
                column: "VolunteeringJobId",
                principalTable: "VolunteeringJobs",
                principalColumn: "VolunteeringJobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplications_ApplicationStatuses_ApplicationStatusId",
                table: "WorkerApplications",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "ApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplications_ClientPosts_ClientPostId",
                table: "WorkerApplications",
                column: "ClientPostId",
                principalTable: "ClientPosts",
                principalColumn: "ClientPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplications_PaidJobs_PaidJobId",
                table: "WorkerApplications",
                column: "PaidJobId",
                principalTable: "PaidJobs",
                principalColumn: "PaidJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplications_Workers_WorkerId",
                table: "WorkerApplications",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPosts_Clients_ClientId",
                table: "ClientPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Users_UserId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PaidJobs_Organizations_OrganizationId",
                table: "PaidJobs");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplications_ApplicationStatuses_ApplicationStatusId",
                table: "VolunteeringApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_VolunteeringApplications_VolunteeringJobs_VolunteeringJobId",
                table: "VolunteeringApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplications_ApplicationStatuses_ApplicationStatusId",
                table: "WorkerApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplications_ClientPosts_ClientPostId",
                table: "WorkerApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplications_PaidJobs_PaidJobId",
                table: "WorkerApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerApplications_Workers_WorkerId",
                table: "WorkerApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkerApplications",
                table: "WorkerApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VolunteeringApplications",
                table: "VolunteeringApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaidJobs",
                table: "PaidJobs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientPosts",
                table: "ClientPosts");

            migrationBuilder.RenameTable(
                name: "WorkerApplications",
                newName: "WorkerApplication");

            migrationBuilder.RenameTable(
                name: "VolunteeringApplications",
                newName: "VolunteeringApplication");

            migrationBuilder.RenameTable(
                name: "PaidJobs",
                newName: "PaidJob");

            migrationBuilder.RenameTable(
                name: "ClientPosts",
                newName: "ClientPost");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplications_WorkerId",
                table: "WorkerApplication",
                newName: "IX_WorkerApplication_WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplications_PaidJobId",
                table: "WorkerApplication",
                newName: "IX_WorkerApplication_PaidJobId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplications_ClientPostId",
                table: "WorkerApplication",
                newName: "IX_WorkerApplication_ClientPostId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerApplications_ApplicationStatusId",
                table: "WorkerApplication",
                newName: "IX_WorkerApplication_ApplicationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteeringApplications_VolunteeringJobId",
                table: "VolunteeringApplication",
                newName: "IX_VolunteeringApplication_VolunteeringJobId");

            migrationBuilder.RenameIndex(
                name: "IX_VolunteeringApplications_ApplicationStatusId",
                table: "VolunteeringApplication",
                newName: "IX_VolunteeringApplication_ApplicationStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_PaidJobs_OrganizationId",
                table: "PaidJob",
                newName: "IX_PaidJob_OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientPosts_ClientId",
                table: "ClientPost",
                newName: "IX_ClientPost_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Users",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkerApplication",
                table: "WorkerApplication",
                column: "WorkerApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VolunteeringApplication",
                table: "VolunteeringApplication",
                column: "VolunteeringApplicationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaidJob",
                table: "PaidJob",
                column: "PaidJobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientPost",
                table: "ClientPost",
                column: "ClientPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPost_Clients_ClientId",
                table: "ClientPost",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_UserId",
                table: "Clients",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Users_UserId",
                table: "Organizations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidJob_Organizations_OrganizationId",
                table: "PaidJob",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplication_ApplicationStatuses_ApplicationStatusId",
                table: "VolunteeringApplication",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VolunteeringApplication_VolunteeringJobs_VolunteeringJobId",
                table: "VolunteeringApplication",
                column: "VolunteeringJobId",
                principalTable: "VolunteeringJobs",
                principalColumn: "VolunteeringJobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplication_ApplicationStatuses_ApplicationStatusId",
                table: "WorkerApplication",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplication_ClientPost_ClientPostId",
                table: "WorkerApplication",
                column: "ClientPostId",
                principalTable: "ClientPost",
                principalColumn: "ClientPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplication_PaidJob_PaidJobId",
                table: "WorkerApplication",
                column: "PaidJobId",
                principalTable: "PaidJob",
                principalColumn: "PaidJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerApplication_Workers_WorkerId",
                table: "WorkerApplication",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "WorkerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Users_UserId",
                table: "Workers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
