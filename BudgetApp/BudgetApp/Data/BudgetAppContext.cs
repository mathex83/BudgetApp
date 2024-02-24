using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models.CSV_loader;
using BudgetApp.Models.CategoryModels;

namespace BudgetApp.Data
{
    public class BudgetAppContext : DbContext
    {
        public BudgetAppContext(DbContextOptions<BudgetAppContext> options)
            : base(options)
        {
        }

        public DbSet<DimDate> DimDate { get; set; }
        public DbSet<CategoryType> CategoryType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<CSV_model> CSV_model { get; set; }
        public DbSet<Trans> Trans { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryType>().HasData(
                new
                {
                    CategoryTypeId = 1,
                    CategoryTypeName = "Income"
                },
                new
                {
                    CategoryTypeId = 2,
                    CategoryTypeName = "Expense"
                });
            modelBuilder.Entity<Category>().HasData(
                new
                {
                    CategoryId = 1,
                    CategoryName = "Fast overførsel",
                    CategoryTypeId = 1
                },
                new
                {
                    CategoryId = 2,
                    CategoryName = "Anden overførsel",
                    CategoryTypeId = 1
                },
                new
                {
                    CategoryId = 3,
                    CategoryName = "Bolig",
                    CategoryTypeId = 2
                },
                new
                {
                    CategoryId = 4,
                    CategoryName = "Bil",
                    CategoryTypeId = 2
                },
                new
                {
                    CategoryId = 5,
                    CategoryName = "Forsikring",
                    CategoryTypeId = 2
                },
                new
                {
                    CategoryId = 6,
                    CategoryName = "Tlf/Internet/TV",
                    CategoryTypeId = 2
                },
                new
                {
                    CategoryId = 7,
                    CategoryName = "Streaming",
                    CategoryTypeId = 2
                }
                );
        }
    }
}
