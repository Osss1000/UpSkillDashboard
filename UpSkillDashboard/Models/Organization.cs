using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class Organization
{
    [Key]
    public int OrganizationId { get; set; }

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }
    public string? Name { get; set; } // ✅ تمت الإضافة


    public string? DocumentationPath { get; set; }

    [Required(ErrorMessage = "Organization role is required.")]
    public string OrganizationRole { get; set; } = null!;

    [Required(ErrorMessage = "User ID is required.")]
    [ForeignKey("User")]
    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<PaidJob> PaidJobs { get; set; } = new List<PaidJob>();
    public virtual User User { get; set; } = null!;
    public virtual ICollection<VolunteeringJob> VolunteeringJobs { get; set; } = new List<VolunteeringJob>();
}
