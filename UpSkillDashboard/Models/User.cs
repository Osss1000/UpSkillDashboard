using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Bio { get; set; }

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? Points { get; set; }

    public string? PhoneNumber { get; set; }

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public virtual Client? Client { get; set; }

    public virtual Organization? Organization { get; set; }

    public virtual Worker? Worker { get; set; }
}
