using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models.CategoryModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        #region SubCategoryCategoryId Primary-end
        public ICollection<Subcategory> Subcategories { get; set; }
        #endregion

        #region CategoryCategoryTypeId Foreign-end
        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        #endregion
    }
}
