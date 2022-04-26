using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        #region SubCategory Many-end
        public ICollection<Subcategory> Subcategories { get; set; }
        #endregion

        #region CategoryType One-end
        public int CategoryTypeId { get; set; }
        public CategoryType CategoryType { get; set; }
        #endregion
    }
}
