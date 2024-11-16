using Microsoft.EntityFrameworkCore;
using EmployeeRegistrationApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeRegistrationApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; } // Ensure this is present

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configurations can be added here if needed
            modelBuilder.Ignore<SelectListGroup>();
        }
    }
}
