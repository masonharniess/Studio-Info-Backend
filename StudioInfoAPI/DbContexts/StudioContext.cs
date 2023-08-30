using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.Entities;
using StudioInfoAPI.Models;

namespace StudioInfoAPI.DbContexts
{
  // The database context is the main class that coordinates Entity Framework functionality for a data model.
  public class StudioContext : DbContext 
  {
    // The options object provides configuration information for how the context should be set up. The : base(options) part calls the constructor of the base DbContext class, passing in the provided options.
    public StudioContext(DbContextOptions<StudioContext> options) : base(options) { }

    // DbSet is a class that represents a collection of entities from a specific table or entity type in a database. It serves as an interface to query, insert, update, and delete records in the corresponding database table.
    public DbSet<StudioEntity> Studios { get; set; } = null!;
  }
}