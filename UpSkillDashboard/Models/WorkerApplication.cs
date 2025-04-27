﻿using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;

public partial class WorkerApplication
{
    public int WorkerApplicationId { get; set; }

    public DateTime ApplyDate { get; set; }

    public int? ClientPostId { get; set; }

    public int? PaidJobId { get; set; }

    public int WorkerId { get; set; }

    public int ApplicationStatusId { get; set; }

    public string ApplicationType { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public virtual ApplicationStatus ApplicationStatus { get; set; } = null!;

    public virtual ClientPost? ClientPost { get; set; }

    public virtual PaidJob? PaidJob { get; set; }

    public virtual Worker Worker { get; set; } = null!;
}
