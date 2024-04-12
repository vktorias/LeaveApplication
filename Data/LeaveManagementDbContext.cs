using LeaveApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LeaveApplication.Data
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveForm> LeaveForms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
               .HasMany(e => e.LeaveForms)
               .WithOne(va => va.Employee)
               .HasForeignKey(va => va.FkEmployeeId);
               

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 5, FirstName = "Vicky", LastName = "Walle"},
                new Employee { EmployeeId = 6, FirstName = "Nelly", LastName = "Nordlund" },
                new Employee { EmployeeId = 7, FirstName = "Melissa", LastName = "Wallström" }

            );
            modelBuilder.Entity<LeaveForm>().HasData(
                new LeaveForm { LeaveApplicationId = 1, StartDate = new DateTime(2024, 04, 11), EndDate = new DateTime(2024, 04, 17), Type = LeaveType.SickLeave, FkEmployeeId = 5 },
                new LeaveForm { LeaveApplicationId = 6, StartDate = new DateTime(2024, 04, 15), EndDate = new DateTime(2024, 04, 22), Type = LeaveType.Vacation, FkEmployeeId = 6 },
                new LeaveForm { LeaveApplicationId = 4, StartDate = new DateTime(2024, 04, 18), EndDate = new DateTime(2024, 05, 18), Type = LeaveType.Vacation, FkEmployeeId = 7 }
                );

        }
    }
}
