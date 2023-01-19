using Microsoft.EntityFrameworkCore;
using MovieList2.Models;
// Creating my datacontext

public class MyDbContext : DbContext
{
  public MyDbContext(DbContextOptions options) : base(options) {}
  public DbSet<Movie> Movies { get; set; }
}