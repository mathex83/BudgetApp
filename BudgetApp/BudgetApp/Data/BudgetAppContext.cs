using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Models;

namespace BudgetApp.Data
{
    public class BudgetAppContext : DbContext
    {
        public BudgetAppContext (DbContextOptions<BudgetAppContext> options)
            : base(options)
        {
        }

        public DbSet<BudgetApp.Models.Category> Category { get; set; }

        public DbSet<BudgetApp.Models.Subcategory> Subcategory { get; set; }
    }
}
