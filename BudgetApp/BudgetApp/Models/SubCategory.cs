using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BudgetApp.Models
{
	public class SubCategory
	{
		public int SubCategoryID { get; set; }

		[Display(Name = "Kategori"), StringLength(30)]
		public string CategoryName { get; set; }
	}
}
