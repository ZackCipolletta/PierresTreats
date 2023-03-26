using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{

  public class Treat
  {
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    [StringLength(50)]
    public string Description { get; set; }
    public int TreatId { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}