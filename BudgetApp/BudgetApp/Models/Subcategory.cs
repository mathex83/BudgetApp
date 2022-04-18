using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Underkategori")]
        public string SubcategoryName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}