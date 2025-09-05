using EmployeeApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
