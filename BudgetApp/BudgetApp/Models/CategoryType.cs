using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class CategoryType
    {
        [Key]
        public int CategoryTypeId { get; set; }
        public string CategoryTypeName { get; set; }

        #region Category Many-end
        public ICollection<Category> Categories { get; set; }
        #endregion
    }
}
