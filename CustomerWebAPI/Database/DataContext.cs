using CustomerWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerWebAPI.Database
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "CustomerDB");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
