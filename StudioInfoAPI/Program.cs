
using Microsoft.EntityFrameworkCore;
using StudioInfoAPI.DbContexts;

namespace StudioInfoAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.

      builder.Services.AddControllers().AddNewtonsoftJson();

      //builder.Services.AddDbContext<StudioContext>(opt => opt.UseInMemoryDatabase("StudioList"));
      
      // set up set up dependency injection for StudioContext using EF Core to connect to an SQLite database.
      // adding DBContext to the services collection means we do not need to use the 'OnConfiguring' method in DbContext class to configure the options again.
      builder.Services.AddDbContext<StudioContext>(DbContextOptions => DbContextOptions.UseSqlite(builder.Configuration["ConnectionStrings:StudioInfoApiDatabase"]));

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapControllers();

      app.Run();
    }
  }
}