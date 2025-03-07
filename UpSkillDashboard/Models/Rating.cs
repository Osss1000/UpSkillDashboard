using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class Rating
{
    [Key]
    public int RatingId { get; set; }

    [Required(ErrorMessage = "Score is required.")]
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
    public int Score { get; set; }

    [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
    public string? Comment { get; set; }

    public DateTime RatingDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Client ID is required.")]
    [ForeignKey("Client")]
    public int ClientId { get; set; }

    [Required(ErrorMessage = "Worker ID is required.")]
    [ForeignKey("Worker")]
    public int WorkerId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual Client Client { get; set; } = null!;
    public virtual Worker Worker { get; set; } = null!;
}
