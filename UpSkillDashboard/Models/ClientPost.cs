using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class ClientPost
{
    [Key]
    public int ClientPostId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; } = null!;

    [Range(0, double.MaxValue, ErrorMessage = "Price cannot be negative.")]
    public decimal? Price { get; set; }

    [Required(ErrorMessage = "Profession is required.")]
    [StringLength(50, ErrorMessage = "Profession cannot exceed 50 characters.")]
    public string? Profession { get; set; }

    public DateTime? DateAndTime { get; set; }

    [StringLength(2550, ErrorMessage = "Details cannot exceed 500 characters.")]
    public string? Details { get; set; }

    [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
    public string? Location { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public string Category { get; set; } = null!;

    [Required(ErrorMessage = "Client ID is required.")]
    [ForeignKey("Client")]
    public int ClientId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }


    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkerApplication> WorkerApplications { get; set; } = new List<WorkerApplication>();
}
