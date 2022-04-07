using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
	public class TransactionType
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int TransactionTypeID { get; set; }
		
		[Display(Name="Type")]
		public string TransactionTypeName { get; set; }
	}
}
