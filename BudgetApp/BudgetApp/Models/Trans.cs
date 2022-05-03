using BudgetApp.Models.CategoryModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class Trans
    {
        [Key]
        public int TransId { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        #region TransAccountId Foreign-end
        public int AccountId { get; set; }
        public Account Account { get; set; }
        #endregion

        #region TransSubCategoryId Foreign-end
        public int SubCategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
        #endregion
    }
}
