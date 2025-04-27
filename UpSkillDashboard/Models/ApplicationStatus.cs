using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;
public enum ApplicationStatusEnum
{
    Pending = 1,
    Approved = 2,
    Rejected = 3
}

public partial class ApplicationStatus
{
    public int ApplicationStatusId { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int Status { get; set; }

    public virtual ICollection<VolunteeringApplication> VolunteeringApplications { get; set; } = new List<VolunteeringApplication>();

    public virtual ICollection<WorkerApplication> WorkerApplications { get; set; } = new List<WorkerApplication>();
}
