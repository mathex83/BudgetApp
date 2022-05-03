using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserAlias { get; set; }

        #region AccountUserId Primary-end
        public ICollection<Account> Accounts { get; set; }
        #endregion
    }
}
