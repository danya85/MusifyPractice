using Core.DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.DomainLayer.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
}