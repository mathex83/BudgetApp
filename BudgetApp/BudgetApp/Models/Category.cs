using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="Kategori")]
        public string CategoryName { get; set; }


        public ICollection<Subcategory> Subcategories { get; set; }
    }
}
