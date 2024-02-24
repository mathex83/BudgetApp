using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AccountBalance { get; set; }

        #region AccountUserId Foreign-end
        public int UserId { get; set; }
        public User User { get; set; }
        #endregion

        #region TransAccountId Primary-end
        public ICollection<Trans> Trans { get; set; }
        #endregion

        #region TransBudgetId Primary-end
        public ICollection<Budget> Budgets { get; set; }
        #endregion
    }
}