using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class PaidJob
{
    [Key]
    public int PaidJobId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = null!;

    [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string? Description { get; set; }

    [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
    public string? Location { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public decimal? Price { get; set; }

    public DateTime? DateAndTime { get; set; }

    public bool IsManuallyClosed { get; set; } = false;

    //testbranch



    [Range(1, int.MaxValue, ErrorMessage = "At least one person is needed.")]
    public int? NumberOfPeopleNeeded { get; set; }

    [Required(ErrorMessage = "Organization ID is required.")]
    [ForeignKey("Organization")]
    public int OrganizationId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual Organization Organization { get; set; } = null!;
    public virtual ICollection<WorkerApplication> WorkerApplications { get; set; } = new List<WorkerApplication>();
}
