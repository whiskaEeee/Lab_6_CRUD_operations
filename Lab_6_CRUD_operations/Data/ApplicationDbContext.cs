using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;
using Lab_6_CRUD_operations.Models;
using Contract = Lab_6_CRUD_operations.Models.Contract;


namespace Lab_6_CRUD_operations.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contract> Contracts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}

