using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BudgetApp.Models.CategoryModels
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }

        public string SubcategoryName { get; set; }


        #region SubCategoryCategoryId Foreign-end
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

        #region TransSubCategoryId Primary-end
        public ICollection<Trans> Trans { get; set; }
        #endregion

        #region BudgetSubCategoryId Primary-end
        public ICollection<Budget> Budgets { get; set; }
        #endregion
    }
}