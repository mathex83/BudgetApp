using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public double AccountBalance { get; set; }
    }
}