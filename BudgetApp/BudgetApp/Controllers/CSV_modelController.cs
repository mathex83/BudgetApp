using BudgetApp.Data;
using BudgetApp.Models.CSV_loader;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BudgetApp.Controllers
{
    public class CSV_modelController : Controller
    {
        private readonly BudgetAppContext _context;

        public CSV_modelController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: CSV_model
        public IActionResult CSVlist()
        {
            FileUpload fileContent = new FileUpload();

            return View(fileContent.fileLines
                .OrderByDescending(c => string.IsNullOrEmpty(c.NameOfTransaction))
                .ThenBy(c => System.DateTime.ParseExact( c.TransactionDate,"dd.MM.yyyy", CultureInfo.InvariantCulture))
                );
        }

        private bool CSV_modelExists(int id)
        {
            return _context.CSV_model.Any(e => e.LineId == id);
        }
    }
}
