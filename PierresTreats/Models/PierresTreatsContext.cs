using Microsoft.EntityFrameworkCore;

namespace PierresTreats.Models
{
  public class PierresTreatsContext : DbContext
  {
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<Treat> Treats { get; set; }
    public DbSet<FlavorTreat> FlavorTreats { get; set; }

    public PierresTreatsContext(DbContextOptions<PierresTreatsContext> options) : base(options)
    {

    }
  }
}