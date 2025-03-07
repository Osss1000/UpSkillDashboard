using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class VolunteeringApplication
{
    [Key]
    public int VolunteeringApplicationId { get; set; }

    public DateTime ApplyDate { get; set; } = DateTime.UtcNow;

    [Required]
    [ForeignKey("VolunteeringJob")]
    public int VolunteeringJobId { get; set; }

    [Required]
    public int ApplicantId { get; set; }  // This can be Client or Worker

    [Required]
    [StringLength(50, ErrorMessage = "Applicant Type cannot exceed 50 characters.")]
    public string ApplicantType { get; set; } = null!;  // Either "Client" or "Worker"

    [Required]
    [ForeignKey("ApplicationStatus")]
    public int ApplicationStatusId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;
    public virtual VolunteeringJob VolunteeringJob { get; set; } = null!;
}
