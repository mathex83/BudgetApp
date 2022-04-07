using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
	public class BudgetOwner
	{
		public int BudgetOwnerID { get; set; }

		[Display(Name="Name"), StringLength(20)]
		public string BudgetOwnerName { get; set; }
	}
}
