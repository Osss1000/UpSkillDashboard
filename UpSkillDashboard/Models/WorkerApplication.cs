using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class WorkerApplication
{
    [Key]
    public int WorkerApplicationId { get; set; }

    public DateTime ApplyDate { get; set; } = DateTime.UtcNow;

    [ForeignKey("ClientPost")]
    public int? ClientPostId { get; set; }

    [ForeignKey("PaidJob")]
    public int? PaidJobId { get; set; }

    [Required]
    [ForeignKey("Worker")]
    public int WorkerId { get; set; }

    [Required]
    [ForeignKey("ApplicationStatus")]
    public int ApplicationStatusId { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Application Type cannot exceed 50 characters.")]
    public string ApplicationType { get; set; } = null!; 

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual PaidJob? PaidJob { get; set; }
    public virtual ClientPost? ClientPost { get; set; }
    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;
    public virtual Worker Worker { get; set; } = null!;
}
