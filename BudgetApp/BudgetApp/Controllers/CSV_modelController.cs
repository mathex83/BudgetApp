using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;
using BudgetApp.Models.CSV_loader;

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
            FileUpload fu = new FileUpload();
            return View(fu.lines);
        }

        private bool CSV_modelExists(int id)
        {
            return _context.CSV_model.Any(e => e.LineId == id);
        }
    }
}
