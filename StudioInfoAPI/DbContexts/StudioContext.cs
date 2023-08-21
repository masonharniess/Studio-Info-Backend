using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.DbContexts
{
  // The database context is the main class that coordinates Entity Framework functionality for a data model.
  public class StudioContext : DbContext
  {
    public StudioContext(DbContextOptions<StudioContext> options) : base(options) { }

    public DbSet<Studio> Studios { get; set; } = null!;
  }
}