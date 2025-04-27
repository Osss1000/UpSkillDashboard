using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;

public partial class PostStatus
{
    public int PostStatusId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ClientPost> ClientPosts { get; set; } = new List<ClientPost>();

    public virtual ICollection<PaidJob> PaidJobs { get; set; } = new List<PaidJob>();

    public virtual ICollection<VolunteeringJob> VolunteeringJobs { get; set; } = new List<VolunteeringJob>();
}
