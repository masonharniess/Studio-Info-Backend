using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.DbContexts
{
  public class StudioContext : DbContext
  {
    public StudioContext(DbContextOptions<StudioContext> options) : base(options) { }

    public DbSet<Studio> Studios { get; set; } = null!;
  }
}