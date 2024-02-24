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
    public class BudgetsController : Controller
    {
        private readonly BudgetAppContext _context;

        public BudgetsController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: Budgets
        public async Task<IActionResult> BudgetList()
        {
            var budgetAppContext = _context.Budget
                .Include(b => b.Subcategory)
                .Include(b => b.Account);
            return View(await budgetAppContext.ToListAsync());
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName");
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName");
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransId,Description,Amount,AccountId,SubCategoryId")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BudgetList));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", budget.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", budget.SubCategoryId);
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", budget.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", budget.SubCategoryId);
            return View(budget);
        }

        // POST: Budget/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransId,Description,Amount,AccountId,SubCategoryId")] Budget budget)
        {
            if (id != budget.BudgetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.BudgetId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(BudgetList));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", budget.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", budget.SubCategoryId);
            return View(budget);
        }

        // GET: Trans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Budget
                .Include(b => b.Account)
                .Include(b => b.Subcategory)
                .FirstOrDefaultAsync(m => m.BudgetId == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budget = await _context.Budget.FindAsync(id);
            _context.Budget.Remove(budget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BudgetList));
        }

        private bool BudgetExists(int id)
        {
            return _context.Budget.Any(e => e.BudgetId == id);
        }
    }
}
