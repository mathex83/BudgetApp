using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models.CSV_loader
{
    public class CSV_model
    {
        [Key]
        public int LineId { get; set; }
        public string TransactionDate { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public string SendingAccount { get; set; }
        public string ReceivingAccount { get; set; }
        public string NameOfTransaction { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Saldo { get; set; }
        public string Currency { get; set; }
        public string TransactionApproved { get; set; }
    }
}
