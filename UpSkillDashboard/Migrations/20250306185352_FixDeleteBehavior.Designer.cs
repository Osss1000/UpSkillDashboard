﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UpSkillDashboard.Data;

#nullable disable

namespace UpSkillDashboard.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250306185352_FixDeleteBehavior")]
    partial class FixDeleteBehavior
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UpSkillDashboard.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("ApplicationStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApplicationStatusId"));

                    b.Property<string>("ApplicationStatusEnum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ApplicationStatusId");

                    b.ToTable("ApplicationStatuses");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("BackNationalIdPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FrontNationalIdPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ClientId");

                    b.HasIndex("NationalId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.ClientPost", b =>
                {
                    b.Property<int>("ClientPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientPostId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientPostId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientPost");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("DocumentationPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrganizationRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.PaidJob", b =>
                {
                    b.Property<int>("PaidJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaidJobId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumberOfPeopleNeeded")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PaidJobId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("PaidJob");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.VolunteeringApplication", b =>
                {
                    b.Property<int>("VolunteeringApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VolunteeringApplicationId"));

                    b.Property<int>("ApplicantId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicantType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ApplicationStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VolunteeringJobId")
                        .HasColumnType("int");

                    b.HasKey("VolunteeringApplicationId");

                    b.HasIndex("ApplicationStatusId");

                    b.HasIndex("VolunteeringJobId");

                    b.ToTable("VolunteeringApplication");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.VolunteeringJob", b =>
                {
                    b.Property<int>("VolunteeringJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VolunteeringJobId"));

                    b.Property<int>("ApplicationStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateAndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Location")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NumberOfPeopleNeeded")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VolunteeringJobId");

                    b.HasIndex("ApplicationStatusId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("VolunteeringJobs");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Worker", b =>
                {
                    b.Property<int>("WorkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerId"));

                    b.Property<string>("BackNationalIdPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClearanceCertificatePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FrontNationalIdPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WorkerId");

                    b.HasIndex("NationalId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.WorkerApplication", b =>
                {
                    b.Property<int>("WorkerApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkerApplicationId"));

                    b.Property<int>("ApplicationStatusId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ApplyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ClientPostId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaidJobId")
                        .HasColumnType("int");

                    b.Property<int>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("WorkerApplicationId");

                    b.HasIndex("ApplicationStatusId");

                    b.HasIndex("ClientPostId");

                    b.HasIndex("PaidJobId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerApplication");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Client", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.User", "User")
                        .WithMany("Clients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.ClientPost", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Organization", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.User", "User")
                        .WithMany("Organizations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.PaidJob", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.Organization", "Organization")
                        .WithMany("PaidJobs")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.VolunteeringApplication", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.ApplicationStatus", "ApplicationStatus")
                        .WithMany("VolunteeringApplications")
                        .HasForeignKey("ApplicationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UpSkillDashboard.Models.VolunteeringJob", "VolunteeringJob")
                        .WithMany("VolunteeringApplications")
                        .HasForeignKey("VolunteeringJobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationStatus");

                    b.Navigation("VolunteeringJob");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.VolunteeringJob", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.ApplicationStatus", "ApplicationStatus")
                        .WithMany("VolunteeringJobs")
                        .HasForeignKey("ApplicationStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("UpSkillDashboard.Models.Organization", "Organization")
                        .WithMany("VolunteeringJobs")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationStatus");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Worker", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.User", "User")
                        .WithMany("Workers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.WorkerApplication", b =>
                {
                    b.HasOne("UpSkillDashboard.Models.ApplicationStatus", "ApplicationStatus")
                        .WithMany("WorkerApplications")
                        .HasForeignKey("ApplicationStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UpSkillDashboard.Models.ClientPost", "ClientPost")
                        .WithMany("WorkerApplications")
                        .HasForeignKey("ClientPostId");

                    b.HasOne("UpSkillDashboard.Models.PaidJob", "PaidJob")
                        .WithMany("WorkerApplications")
                        .HasForeignKey("PaidJobId");

                    b.HasOne("UpSkillDashboard.Models.Worker", "Worker")
                        .WithMany()
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationStatus");

                    b.Navigation("ClientPost");

                    b.Navigation("PaidJob");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.ApplicationStatus", b =>
                {
                    b.Navigation("VolunteeringApplications");

                    b.Navigation("VolunteeringJobs");

                    b.Navigation("WorkerApplications");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.ClientPost", b =>
                {
                    b.Navigation("WorkerApplications");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.Organization", b =>
                {
                    b.Navigation("PaidJobs");

                    b.Navigation("VolunteeringJobs");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.PaidJob", b =>
                {
                    b.Navigation("WorkerApplications");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.User", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Organizations");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("UpSkillDashboard.Models.VolunteeringJob", b =>
                {
                    b.Navigation("VolunteeringApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
