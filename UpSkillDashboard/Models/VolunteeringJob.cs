using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class VolunteeringJob
{
    [Key]
    public int VolunteeringJobId { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
    public string? Location { get; set; }

    public DateTime? DateAndTime { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "At least one person is needed.")]
    public int? NumberOfPeopleNeeded { get; set; }

    [Required]
    [ForeignKey("Organization")]
    public int OrganizationId { get; set; }

    [Required]
    [ForeignKey("ApplicationStatus")]
    public int ApplicationStatusId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual Organization Organization { get; set; } = null!;
    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;
    public virtual ICollection<VolunteeringApplication> VolunteeringApplications { get; set; } = new List<VolunteeringApplication>();
}
