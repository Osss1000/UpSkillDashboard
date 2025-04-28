using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;

public enum OrganizationRoleEnum
{
    ForProfit = 1,
    Voluntary = 2
}

public partial class Organization
{
    public int OrganizationId { get; set; }

    public string? Description { get; set; }

    public string? DocumentationPath { get; set; }
    
    public int UserId { get; set; }

    public string? Name { get; set; }
    
    public virtual User User { get; set; } = null!;

    public virtual ICollection<VolunteeringJob> VolunteeringJobs { get; set; } = new List<VolunteeringJob>();
}
