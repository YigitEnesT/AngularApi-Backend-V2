using AngularAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AngularAPI.Data
{
    public class AngularAPIDbContext : DbContext
    {
        public AngularAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
