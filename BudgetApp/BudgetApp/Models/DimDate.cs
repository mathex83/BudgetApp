using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace BudgetApp.Models
{
    public class DimDate
    {
        [DataType(DataType.Date),Key]
        public DateTime DateISO { get; set; }
        public string DateDK { get; set; }
        public int WeekInt { get; set; }
        public int YearInt { get; set; }
        public int QuarterInt { get; set; }
        public int MonthInt { get; set; }
        public int DayInt { get; set; }
        public string DayNameEN { get; set; }
        public string DayNameDK { get; set; }
        public int DayOfWeekInt { get; set; }
    }
}
