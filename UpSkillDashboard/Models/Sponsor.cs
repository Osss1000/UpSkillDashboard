using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpSkillDashboard.Models;

public partial class Sponsor
{
    [Key]
    public int SponsorId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
    public string Email { get; set; } = null!;

    [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
    public string? PhoneNumber { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedDate { get; set; }

    public virtual ICollection<Advertisement> Advertisements { get; set; } = new List<Advertisement>();
}
