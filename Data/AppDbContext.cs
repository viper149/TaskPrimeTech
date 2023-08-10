using Microsoft.EntityFrameworkCore;
using PrimeTechApp.Models;

namespace PrimeTechApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
    }
}