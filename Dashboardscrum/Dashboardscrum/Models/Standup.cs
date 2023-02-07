using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dashboardscrum.Models;

public class Standup
{
    [Key, Column("StandupId")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid StandupId { get; set; }
        
    [Required(ErrorMessage = "{0} moet ingevuld worden.")]
    public string? Gisteren { get; set; } 
    
    [Required(ErrorMessage = "{0} moet ingevuld worden.")]
    public string? Vandaag { get; set; } 
    
    [Column("ApplicationUserId")]
    [ForeignKey("ApplicationUserId")]
    public string? ApplicationUserId { get; set; }

    [ReadOnly(true)] public ApplicationUser? ApplicationUser { get; set; }

    public DateTime Datum { get; set; }
}