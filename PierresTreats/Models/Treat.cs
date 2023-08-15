using System.ComponentModel.DataAnnotations;

namespace PierresTreats.Models
{

  public class Treat
  {
    [Required(ErrorMessage = "Name cannot be Empty. Please Enter a name.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be between 2 and 20 characters")]
    [RegularExpression(@"^[A-Za-z0-9?.&#$%@!,!()]+(?:\s+[A-Za-z0-9?.&#$%@!,!()]+)*$", ErrorMessage = "Name may only contain letters, numbers, single spaces and special characters ?.,*&#()$%@! or $.")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Description cannot be Empty.")]
    [StringLength(150, MinimumLength = 5, ErrorMessage = "Description should be between 5 and 150 characters")]
    [RegularExpression(@"^[A-Za-z0-9?.&#$%@!,!()]+(?:\s+[A-Za-z0-9?.&#$%@!,!()]+)*$", ErrorMessage = "Description may only contain letters, numbers, single spaces and special characters ?.,*&#()$%@! or $.")]
    public string Description { get; set; }
    public int TreatId { get; set; }
    public List<FlavorTreat> JoinEntities { get; }
  }
}