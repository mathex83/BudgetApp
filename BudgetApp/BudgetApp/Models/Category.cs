using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models
{
	public class Category
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CategoryID { get; set; }

		[Display(Name = "Kategori"), StringLength(30)]
		public string CategoryName { get; set; }		
	}
}
