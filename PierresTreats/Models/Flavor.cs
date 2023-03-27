using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{

  public class Flavor
  {
    [Required(ErrorMessage = "Name cannot be Empty. Please Enter a name.")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be between 2 and 20 characters")]
    [RegularExpression(@"^[A-Za-z0-9?.&#$%@!()]+(?:\s+[A-Za-z0-9?.&#$%@!()]+)*$", ErrorMessage = "Name may only contain letters, numbers, single spaces and special characters ?.*&#()$%@! or $.")]
    public string Name { get; set; }
    public int FlavorId { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}