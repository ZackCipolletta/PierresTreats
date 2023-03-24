using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{

  public class Flavor
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public int FlavorId { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}