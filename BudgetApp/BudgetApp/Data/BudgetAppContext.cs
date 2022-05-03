using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models.CSV_loader;
using BudgetApp.Models.CategoryModels;

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
        public DbSet<CSV_model> CSV_model { get; set; }
        public DbSet<Trans> Trans { get; set; }
        public DbSet<BudgetApp.Models.User> User { get; set; }
    }
}
