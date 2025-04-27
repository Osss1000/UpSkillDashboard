using System;
using System.Collections.Generic;

namespace UpSkillDashboard.Models;

public partial class Profession
{
    public int ProfessionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ClientPost> ClientPosts { get; set; } = new List<ClientPost>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
