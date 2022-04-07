using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
	public class YearData
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Year",Order = -5)]
		public int YearDataID { get; set; }		
	}
}
