using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
	public class MonthData
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Range(1,12), Display(Order = -5)]
		public int MonthDataID { get; set; }

		[Display(Name = "Month"), StringLength(3)]
		public string MonthDataString { get; set; }
	}
}
