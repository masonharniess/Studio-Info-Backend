using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.DbContexts
{
  // The database context is the main class that coordinates Entity Framework functionality for a data model.
  public class StudioContext : DbContext
  {
    public StudioContext(DbContextOptions<StudioContext> options) : base(options) { }

    // DbSet is a class that represents a collection of entities from a specific table or entity type in a database. It serves as an interface to query, insert, update, and delete records in the corresponding database table.
    public DbSet<Studio> Studios { get; set; } = null!;
  }
}