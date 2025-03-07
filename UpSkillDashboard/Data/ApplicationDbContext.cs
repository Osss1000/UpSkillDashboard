using Microsoft.EntityFrameworkCore;
using UpSkillDashboard.Models;

namespace UpSkillDashboard.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ✅ تضمين جميع الجداول في قاعدة البيانات
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<VolunteeringJob> VolunteeringJobs { get; set; }
        public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public virtual DbSet<PaidJob> PaidJobs { get; set; }
        public virtual DbSet<ClientPost> ClientPosts { get; set; }
        public virtual DbSet<WorkerApplication> WorkerApplications { get; set; }
        public virtual DbSet<VolunteeringApplication> VolunteeringApplications { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
        public virtual DbSet<Advertisement> Advertisements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ ضبط جدول User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Points).IsRequired(false);
            });

            // ✅ ضبط علاقة One-to-One بين User و Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.ClientId);
                entity.HasIndex(e => e.NationalId).IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Client) // ✅ One-to-One
                    .HasForeignKey<Client>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ✅ ضبط علاقة One-to-One بين User و Worker
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.WorkerId);
                entity.HasIndex(e => e.NationalId).IsUnique();

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Worker) // ✅ One-to-One
                    .HasForeignKey<Worker>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ✅ ضبط علاقة One-to-One بين User و Organization
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationId);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Organization) // ✅ One-to-One
                    .HasForeignKey<Organization>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // ✅ ضبط علاقة VolunteeringJob مع ApplicationStatus
            modelBuilder.Entity<VolunteeringJob>(entity =>
            {
                entity.HasKey(e => e.VolunteeringJobId);

                entity.HasOne(d => d.ApplicationStatus)
                    .WithMany(p => p.VolunteeringJobs)
                    .HasForeignKey(d => d.ApplicationStatusId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقة PaidJob مع Organization
            modelBuilder.Entity<PaidJob>(entity =>
            {
                entity.HasKey(e => e.PaidJobId);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.PaidJobs)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقة ClientPost مع Client
            modelBuilder.Entity<ClientPost>(entity =>
            {
                entity.HasKey(e => e.ClientPostId);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPosts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقة WorkerApplication مع ApplicationStatus
            modelBuilder.Entity<WorkerApplication>(entity =>
            {
                entity.HasKey(e => e.WorkerApplicationId);

                entity.HasOne(d => d.ApplicationStatus)
                    .WithMany(p => p.WorkerApplications)
                    .HasForeignKey(d => d.ApplicationStatusId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقة VolunteeringApplication مع ApplicationStatus
            modelBuilder.Entity<VolunteeringApplication>(entity =>
            {
                entity.HasKey(e => e.VolunteeringApplicationId);

                entity.HasOne(d => d.ApplicationStatus)
                    .WithMany(p => p.VolunteeringApplications)
                    .HasForeignKey(d => d.ApplicationStatusId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقات التقييمات بين Client و Worker
            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط علاقة Advertisement مع Sponsor
            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasKey(e => e.AdvertisementId);

                entity.HasOne(d => d.Sponsor)
                    .WithMany(p => p.Advertisements)
                    .HasForeignKey(d => d.SponsorId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            // ✅ ضبط جدول Sponsor
            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasKey(e => e.SponsorId);
            });
        }
    }
}
