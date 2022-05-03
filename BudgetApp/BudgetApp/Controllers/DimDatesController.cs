using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudgetApp.Data;
using BudgetApp.Models;

namespace BudgetApp.Controllers
{
    public class DimDatesController : Controller
    {
        private readonly BudgetAppContext _context;

        public DimDatesController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: DimDates
        public async Task<IActionResult> DimDateList()
        {
            List<DimDate> datesList = await _context.DimDate.ToListAsync();
            datesList = datesList.Skip(18263).Take(18263).ToList();
            return View(datesList);
        }        
    }
}
