using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UpSkillDashboard.Models;

public enum Role
{
    Client = 1,
    Worker = 2,
    Organization = 3
}
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Role is required.")]
    public string Role { get; set; } = null!; 

    public int? Points { get; set; }
    public string? PhoneNumber { get; set; } // ✅ تمت الإضافة

    [ValidateNever]

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    [ValidateNever]

    public DateTime? ModifiedDate { get; set; }
    [ValidateNever]
    public Client Client { get; set; }
    [ValidateNever]

    public virtual Organization Organization { get; set; }
    [ValidateNever]

    public Worker Worker { get; set; }
}
