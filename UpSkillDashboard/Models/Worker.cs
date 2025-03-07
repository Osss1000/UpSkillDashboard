using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class Worker
{
    [Key]
    public int WorkerId { get; set; }

    [Range(0, 100, ErrorMessage = "Experience must be between 0 and 100 years.")]
    public int? Experience { get; set; }

    [Required(ErrorMessage = "Profession is required.")]
    [StringLength(50, ErrorMessage = "Profession cannot exceed 50 characters.")]
    public string? Profession { get; set; }

    [Required(ErrorMessage = "National ID is required.")]
    [RegularExpression("^[0-9]{14}$", ErrorMessage = "National ID must be 14 digits.")]
    public string? NationalId { get; set; }
    public string? Address { get; set; } // ✅ تمت الإضافة
    public decimal? HourlyRate { get; set; } // ✅ تمت الإضافة
    public string? FrontNationalIdPath { get; set; }
    public string? BackNationalIdPath { get; set; }
    public string? ClearanceCertificatePath { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    [ForeignKey("User")]
    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual User User { get; set; } = null!;
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
