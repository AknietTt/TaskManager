using Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace DAL{
    public class ApplicationDbContext:DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Domain.Models.Task> Tasks { get; set; }

        
    }
}