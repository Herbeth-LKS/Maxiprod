using Microsoft.EntityFrameworkCore;
using HouseholdExpenses.Models;

namespace HouseholdExpenses.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
