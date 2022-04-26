using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
    public class BudgetAppContext : DbContext
    {
        public BudgetAppContext (DbContextOptions<BudgetAppContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryType> CategoryType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Account> Account { get; set; }
        
    }
}
