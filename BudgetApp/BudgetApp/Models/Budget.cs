using BudgetApp.Models.CategoryModels;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }
        [Range(minimum:2000,maximum:2200)]
        public int BudgetYear { get; set; } = 2000;
        public int BudgetMonth { get; set; } = 1;
        public int Amount { get; set; } = 0;

        #region BudgetSubCategoryId Foreign-end
        public int SubCategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        #endregion

        #region BudgetAccountId Foreign-end
        public int AccountId { get; set; }
        public Account Account { get; set; }
        #endregion
    }
}
