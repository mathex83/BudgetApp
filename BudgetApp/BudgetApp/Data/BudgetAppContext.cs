using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models.CSV_loader;

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
        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<BudgetApp.Models.CSV_loader.CSV_model> CSV_model { get; set; }
    }
}
