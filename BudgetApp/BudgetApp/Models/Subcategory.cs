using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }

        public string SubcategoryName { get; set; }


        #region SubCategory one-end
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        #endregion
    }
}