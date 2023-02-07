using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Dashboardscrum.Models;

public class ApplicationUser : IdentityUser
{
    [NotMapped] public virtual ICollection<Team>? Teams { get; set; }
    [NotMapped] public virtual ICollection<Standup>? Standups { get; set; }
  
    public int Aanwezigheid { get; set; }

    public string? NFC { get; set; }

    [Column("TeamId")]
    [ForeignKey("TeamId")]
    public string? TeamId { get; set; }
    public int Role { get; set; }
}