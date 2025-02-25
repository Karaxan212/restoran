using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Controllers
{
    public class TablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Tables/
        public async Task<IActionResult> Index()
        {
            var tables = await _context.Tables.ToListAsync();
            return View(tables);
        }

        // GET: /Tables/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // GET: /Tables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Tables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Tables.Add(table);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: /Tables/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: /Tables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Table table)
        {
            if (id != table.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(table);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TableExists(table.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: /Tables/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: /Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var table = await _context.Tables.FindAsync(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> TableExists(int id)
        {
            return await _context.Tables.AnyAsync(e => e.Id == id);
        }
    }
}
