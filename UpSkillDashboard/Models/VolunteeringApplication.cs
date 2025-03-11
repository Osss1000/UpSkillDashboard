using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models
{
    public enum ApplicantTypeEnum
    {
        Client,
        Worker
    }

    public partial class VolunteeringApplication
    {
        [Key]
        public int VolunteeringApplicationId { get; set; }

        public DateTime ApplyDate { get; set; } = DateTime.UtcNow;

        [Required]
        [ForeignKey("VolunteeringJob")]
        public int VolunteeringJobId { get; set; }

        [Required]
        public ApplicantTypeEnum ApplicantType { get; set; }  // ✅ Now using Enum instead of string

        // ✅ Separate Foreign Keys for Worker & Client
        [ForeignKey("Worker")]
        public int? WorkerId { get; set; }

        [ForeignKey("Client")]
        public int? ClientId { get; set; }

        [Required]
        [ForeignKey("ApplicationStatus")]
        public int ApplicationStatusId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }

        // ✅ Navigation Properties
        public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;
        public virtual VolunteeringJob VolunteeringJob { get; set; } = null!;
        public virtual Worker? Worker { get; set; }
        public virtual Client? Client { get; set; }
    }
}