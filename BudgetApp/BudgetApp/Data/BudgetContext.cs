using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Data
{
	public class BudgetContext : DbContext
	{
		public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
		{

		}

		public DbSet<TransactionType> TransactionTypes { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
		public DbSet<BudgetOwner> BudgetOwners { get; set; }
		public DbSet<MonthData> MonthData { get; set; }
		public DbSet<YearData> YearData { get; set; }
		

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			Database.ExecuteSqlRawAsync(@"SET LANGUAGE Danish;");
            modelBuilder.Entity<MonthData>()
				.HasData(
					new MonthData { MonthDataID = 1, MonthDataString = "Jan" }
					, new MonthData { MonthDataID = 2, MonthDataString = "Feb" }
					, new MonthData { MonthDataID = 3, MonthDataString = "Mar" }
					, new MonthData { MonthDataID = 4, MonthDataString = "Apr" }
					, new MonthData { MonthDataID = 5, MonthDataString = "Maj" }
					, new MonthData { MonthDataID = 6, MonthDataString = "Jun" }
					, new MonthData { MonthDataID = 7, MonthDataString = "Jul" }
					, new MonthData { MonthDataID = 8, MonthDataString = "Aug" }
					, new MonthData { MonthDataID = 9, MonthDataString = "Sep" }
					, new MonthData { MonthDataID = 10, MonthDataString = "Okt" }
					, new MonthData { MonthDataID = 11, MonthDataString = "Nov" }
					, new MonthData { MonthDataID = 12, MonthDataString = "Dec" }
				);

			modelBuilder.Entity<YearData>()				
				.HasData(
					new YearData { YearDataID = 2001 }
					, new YearData { YearDataID = 2002 }
					, new YearData { YearDataID = 2003 }
					, new YearData { YearDataID = 2004 }
					, new YearData { YearDataID = 2005 }
					, new YearData { YearDataID = 2006 }
					, new YearData { YearDataID = 2007 }
					, new YearData { YearDataID = 2008 }
					, new YearData { YearDataID = 2010 }
					, new YearData { YearDataID = 2011 }
					, new YearData { YearDataID = 2012 }
					, new YearData { YearDataID = 2013 }
					, new YearData { YearDataID = 2014 }
					, new YearData { YearDataID = 2015 }
					, new YearData { YearDataID = 2016 }
					, new YearData { YearDataID = 2017 }
					, new YearData { YearDataID = 2018 }
					, new YearData { YearDataID = 2019 }
					, new YearData { YearDataID = 2020 }
					, new YearData { YearDataID = 2021 }
					, new YearData { YearDataID = 2022 }
					, new YearData { YearDataID = 2023 }
					, new YearData { YearDataID = 2024 }
					, new YearData { YearDataID = 2025 }
					, new YearData { YearDataID = 2026 }
					, new YearData { YearDataID = 2027 }
					, new YearData { YearDataID = 2028 }
					, new YearData { YearDataID = 2029 }
					, new YearData { YearDataID = 2030 }
				);

			modelBuilder.Entity<TransactionType>()
				.HasData(
					new TransactionType { TransactionTypeID = 1, TransactionTypeName = "Udgifter" }
					, new TransactionType { TransactionTypeID = 2, TransactionTypeName = "Indtægter" }
				);			

			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryID = 1, CategoryName = "Bolig" }
				, new Category { CategoryID = 2, CategoryName = "Forsikring", }
				, new Category { CategoryID = 3, CategoryName = "Multimedier", }
				, new Category { CategoryID = 4, CategoryName = "Transport", }
				);
		}		
    }
}
