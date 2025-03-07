using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public enum ApplicationStatusEnum
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}

public partial class ApplicationStatus
{
    [Key]
    public int ApplicationStatusId { get; set; }

    [Required(ErrorMessage = "Application status is required.")]
    public string ApplicationStatusEnum { get; set; }

    [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<VolunteeringApplication> VolunteeringApplications { get; set; } = new List<VolunteeringApplication>();
    public virtual ICollection<VolunteeringJob> VolunteeringJobs { get; set; } = new List<VolunteeringJob>();
    public virtual ICollection<WorkerApplication> WorkerApplications { get; set; } = new List<WorkerApplication>();
}
