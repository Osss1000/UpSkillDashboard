using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UpSkillDashboard.Models
{
    public class Profession
    {
        public int ProfessionId { get; set; }

        [Required(ErrorMessage = "Profession is required.")]
        [StringLength(50, ErrorMessage = "Profession cannot exceed 50 characters.")]
        public string? Name { get; set; }  // ✅ Applied validations here

        public ICollection<Worker> Workers { get; set; } = new List<Worker>();

        // Optional: Add image path or category type if needed later
    }
}