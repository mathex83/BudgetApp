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
    public class CategoriesController : Controller
    {
        private readonly BudgetAppContext _context;
        private readonly string modelName = "Category";

        public CategoriesController(BudgetAppContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> CategoryList()
        {
            var budgetAppContext = _context.Category.Include(sc => sc.CategoryType);
            List<Category> categories = await budgetAppContext.ToListAsync();
            //await _context.Category.ToListAsync();
            categories = categories
                .OrderByDescending(ct => ct.CategoryType.CategoryTypeId)
                .ThenBy(c => c.CategoryId).ToList();
            ViewData["Title"] = modelName + "-list";
            return View(categories);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            ViewData["CategoryTypeId"] = new SelectList(
                _context.CategoryType, 
                "CategoryTypeId",
                "CategoryTypeName");
            ViewData["Title"] = "Create new " + modelName;
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CategoryId,CategoryName,CategoryTypeId")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CategoryList));
            }
            ViewData["CategoryTypeId"] = new SelectList(
                _context.CategoryType,
                "CategoryTypeId",
                "CategoryTypeName",
                category.CategoryTypeId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["Title"] = "Edit " + modelName;
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["CategoryTypeId"] = new SelectList(
                _context.CategoryType,
                "CategoryTypeId",
                "CategoryTypeName",
                category.CategoryTypeId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, 
            [Bind("CategoryId,CategoryName,CategoryTypeId")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CategoryList));
            }
            ViewData["CategoryTypeId"] = new SelectList(
                _context.CategoryType,
                "CategoryTypeId",
                "CategoryTypeName",
                category.CategoryTypeId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["Title"] = "Delete " + modelName;
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .Include(c => c.CategoryType)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CategoryList));
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
