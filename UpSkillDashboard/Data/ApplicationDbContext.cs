using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Models;

namespace UpSkillDashboard.Data;
public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientPost> ClientPosts { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<PaidJob> PaidJobs { get; set; }

    public virtual DbSet<PostStatus> PostStatuses { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Sponsor> Sponsors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolunteeringApplication> VolunteeringApplications { get; set; }

    public virtual DbSet<VolunteeringJob> VolunteeringJobs { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    public virtual DbSet<WorkerApplication> WorkerApplications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=UpSkill;User Id=sa;Password=SqlServer123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advertisement>(entity =>
        {
            entity.HasIndex(e => e.SponsorId, "IX_Advertisements_SponsorId");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Sponsor).WithMany(p => p.Advertisements)
                .HasForeignKey(d => d.SponsorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(e => e.NationalId, "IX_Clients_NationalId").IsUnique();

            entity.HasIndex(e => e.UserId, "IX_Clients_UserId").IsUnique();

            entity.HasOne(d => d.User).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ClientPost>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_ClientPosts_ClientId");

            entity.HasIndex(e => e.PostStatusId, "IX_ClientPosts_PostStatusId");

            entity.HasIndex(e => e.ProfessionId, "IX_ClientPosts_ProfessionId");

            entity.Property(e => e.Details).HasMaxLength(2550);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Client).WithMany(p => p.ClientPosts)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PostStatus).WithMany(p => p.ClientPosts)
                .HasForeignKey(d => d.PostStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Profession).WithMany(p => p.ClientPosts)
                .HasForeignKey(d => d.ProfessionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Organizations_UserId").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(500);

            entity.HasOne(d => d.User).WithOne(p => p.Organization)
                .HasForeignKey<Organization>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PaidJob>(entity =>
        {
            entity.HasIndex(e => e.OrganizationId, "IX_PaidJobs_OrganizationId");

            entity.HasIndex(e => e.PostStatusId, "IX_PaidJobs_PostStatusId");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Organization).WithMany(p => p.PaidJobs)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PostStatus).WithMany(p => p.PaidJobs)
                .HasForeignKey(d => d.PostStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PostStatus>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasIndex(e => e.ClientId, "IX_Ratings_ClientId");

            entity.HasIndex(e => e.WorkerId, "IX_Ratings_WorkerId");

            entity.Property(e => e.Comment).HasMaxLength(500);

            entity.HasOne(d => d.Client).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Worker).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Users_Email").IsUnique();

            entity.Property(e => e.PasswordHash).HasDefaultValueSql("(0x)");
            entity.Property(e => e.PasswordSalt).HasDefaultValueSql("(0x)");
        });

        modelBuilder.Entity<VolunteeringApplication>(entity =>
        {
            entity.HasIndex(e => e.ApplicationStatusId, "IX_VolunteeringApplications_ApplicationStatusId");

            entity.HasIndex(e => e.ClientId, "IX_VolunteeringApplications_ClientId");

            entity.HasIndex(e => e.VolunteeringJobId, "IX_VolunteeringApplications_VolunteeringJobId");

            entity.HasIndex(e => e.WorkerId, "IX_VolunteeringApplications_WorkerId");

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.VolunteeringApplications)
                .HasForeignKey(d => d.ApplicationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Client).WithMany(p => p.VolunteeringApplications).HasForeignKey(d => d.ClientId);

            entity.HasOne(d => d.VolunteeringJob).WithMany(p => p.VolunteeringApplications)
                .HasForeignKey(d => d.VolunteeringJobId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Worker).WithMany(p => p.VolunteeringApplications).HasForeignKey(d => d.WorkerId);
        });

        modelBuilder.Entity<VolunteeringJob>(entity =>
        {
            entity.HasIndex(e => e.OrganizationId, "IX_VolunteeringJobs_OrganizationId");

            entity.HasIndex(e => e.PostStatusId, "IX_VolunteeringJobs_PostStatusId");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Organization).WithMany(p => p.VolunteeringJobs)
                .HasForeignKey(d => d.OrganizationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.PostStatus).WithMany(p => p.VolunteeringJobs)
                .HasForeignKey(d => d.PostStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasIndex(e => e.NationalId, "IX_Workers_NationalId").IsUnique();

            entity.HasIndex(e => e.ProfessionId, "IX_Workers_ProfessionId");

            entity.HasIndex(e => e.UserId, "IX_Workers_UserId").IsUnique();

            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Profession).WithMany(p => p.Workers)
                .HasForeignKey(d => d.ProfessionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithOne(p => p.Worker)
                .HasForeignKey<Worker>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WorkerApplication>(entity =>
        {
            entity.HasIndex(e => e.ApplicationStatusId, "IX_WorkerApplications_ApplicationStatusId");

            entity.HasIndex(e => e.ClientPostId, "IX_WorkerApplications_ClientPostId");

            entity.HasIndex(e => e.PaidJobId, "IX_WorkerApplications_PaidJobId");

            entity.HasIndex(e => e.WorkerId, "IX_WorkerApplications_WorkerId");

            entity.HasOne(d => d.ApplicationStatus).WithMany(p => p.WorkerApplications)
                .HasForeignKey(d => d.ApplicationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ClientPost).WithMany(p => p.WorkerApplications).HasForeignKey(d => d.ClientPostId);

            entity.HasOne(d => d.PaidJob).WithMany(p => p.WorkerApplications).HasForeignKey(d => d.PaidJobId);

            entity.HasOne(d => d.Worker).WithMany(p => p.WorkerApplications)
                .HasForeignKey(d => d.WorkerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
