using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetApp.Models.CSV_loader
{
    public class CSV_model
    {
        [Key]
        public int LineId { get; set; }
        public string Bogføringsdato { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Beløb { get; set; }
        public string Afsender { get; set; }
        public string Modtager { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Saldo { get; set; }
        public string Valuta { get; set; }
        public string Afstemt { get; set; }
    }
}
