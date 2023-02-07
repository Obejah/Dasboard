using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboardscrum.Models;

public class Team
{
    [Key, Column("TeamId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid TeamId { get; set; }
        
    [Required(ErrorMessage = "{0} moet ingevuld worden.")]
    [Display(Name = "Naam*")]
    public string? Name { get; set; } 
    
    public int? Hulp { get; set; }
}