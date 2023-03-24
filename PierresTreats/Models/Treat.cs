using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{

  public class Treat
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int TreatId { get; set; }
    public List<Flavor> JoinEntities { get; }
  }
}