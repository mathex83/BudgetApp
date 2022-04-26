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
    public class SubcategoriesController : Controller
    {
        private readonly BudgetAppContext _context;
        private readonly string modelName = "Sub-category";

        public SubcategoriesController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: Subcategories
        public async Task<IActionResult> SubcategoryList()
        {
            var budgetAppContext = _context.Subcategory.Include(sc => sc.Category)
                .ThenInclude(cat => cat.CategoryType);
            List<Subcategory> subcategories = await budgetAppContext.ToListAsync();
            subcategories = subcategories
                .OrderByDescending(sc => sc.Category.CategoryType.CategoryTypeId)
                .ThenBy(sc => sc.Category.CategoryId)
                .ThenBy(sc => sc.SubcategoryName)
                .ToList();
            ViewData["Title"] = modelName + "-list";
            return View(subcategories);
        }

        // GET: Subcategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(
                _context.Category, 
                "CategoryId", 
                "CategoryName");
            ViewData["Title"] = "Create new " + modelName;
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("SubcategoryId,SubcategoryName,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SubcategoryList));
            }
            ViewData["CategoryId"] = new SelectList(
                _context.Category, 
                "CategoryId", 
                "CategoryName", 
                subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Title"] = "Edit " + modelName;
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategory.FindAsync(id);
            if (subcategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(
                _context.Category,
                "CategoryId",
                "CategoryName",
                subcategory.CategoryId);
            return View(subcategory);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("SubcategoryId,SubcategoryName,CategoryId")] Subcategory subcategory)
        {
            if (id != subcategory.SubcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoryExists(subcategory.SubcategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SubcategoryList));
            }
            ViewData["CategoryId"] = new SelectList(
                _context.Category, 
                "CategoryId", 
                "CategoryName", 
                subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Delete " + modelName;
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategory
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.SubcategoryId == id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategory = await _context.Subcategory.FindAsync(id);
            _context.Subcategory.Remove(subcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(SubcategoryList));
        }

        private bool SubcategoryExists(int id)
        {
            return _context.Subcategory.Any(e => e.SubcategoryId == id);
        }
    }
}
