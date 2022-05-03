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
    public class TransController : Controller
    {
        private readonly BudgetAppContext _context;

        public TransController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: Trans
        public async Task<IActionResult> TransactionList()
        {
            var budgetAppContext = _context.Trans
                .Include(t => t.Account)
                .Include(t => t.Subcategory);
            return View(await budgetAppContext.ToListAsync());
        }       

        // GET: Trans/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName");
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName");
            return View();
        }

        // POST: Trans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransId,Description,Amount,AccountId,SubCategoryId")] Trans trans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TransactionList));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", trans.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", trans.SubCategoryId);
            return View(trans);
        }

        // GET: Trans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans.FindAsync(id);
            if (trans == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", trans.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", trans.SubCategoryId);
            return View(trans);
        }

        // POST: Trans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransId,Description,Amount,AccountId,SubCategoryId")] Trans trans)
        {
            if (id != trans.TransId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransExists(trans.TransId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(TransactionList));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "AccountID", "AccountName", trans.AccountId);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategory, "SubcategoryId", "SubcategoryName", trans.SubCategoryId);
            return View(trans);
        }

        // GET: Trans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trans = await _context.Trans
                .Include(t => t.Account)
                .Include(t => t.Subcategory)
                .FirstOrDefaultAsync(m => m.TransId == id);
            if (trans == null)
            {
                return NotFound();
            }

            return View(trans);
        }

        // POST: Trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trans = await _context.Trans.FindAsync(id);
            _context.Trans.Remove(trans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TransactionList));
        }

        private bool TransExists(int id)
        {
            return _context.Trans.Any(e => e.TransId == id);
        }
    }
}
