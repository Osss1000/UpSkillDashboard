using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    /// <inheritdoc />
    public partial class FixDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPosts_Clients_ClientId",
                table: "ClientPosts");

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

            migrationBuilder.DropColumn(
                name: "WorkerPoints",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ClientPoints",
                table: "Clients");

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

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "ApplicationStatuses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ApplicationStatuses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationStatusEnum",
                table: "ApplicationStatuses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPost_Clients_ClientId",
                table: "ClientPost");

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
                name: "Points",
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

            migrationBuilder.AddColumn<int>(
                name: "WorkerPoints",
                table: "Workers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientPoints",
                table: "Clients",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "ApplicationStatuses",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "ApplicationStatuses",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationStatusEnum",
                table: "ApplicationStatuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    WorkerId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    RatingDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Clients",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Ratings_Workers",
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
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
                    SponsorId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_Advertisements_Sponsors_SponsorId",
                        column: x => x.SponsorId,
                        principalTable: "Sponsors",
                        principalColumn: "SponsorId",
                        onDelete: ReferentialAction.Cascade);
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
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaidJobs_Organizations_OrganizationId",
                table: "PaidJobs",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
