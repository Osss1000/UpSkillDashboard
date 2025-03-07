using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class Client
{
    [Key]
    public int ClientId { get; set; }

    [Required(ErrorMessage = "National ID is required.")]
    [RegularExpression("^[0-9]{14}$", ErrorMessage = "National ID must be exactly 14 digits.")]
    public string? NationalId { get; set; }

    public string? FrontNationalIdPath { get; set; }
    public string? BackNationalIdPath { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    [ForeignKey("User")]
    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }
    public string? Address { get; set; } 


    public virtual User User { get; set; } = null!;

    public virtual ICollection<ClientPost> ClientPosts { get; set; } = new List<ClientPost>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
