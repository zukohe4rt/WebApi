using BaltaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BaltaAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=shared");
    
}