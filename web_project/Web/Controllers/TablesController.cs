using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace TablesController.Controllers
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TablesController : Controller
    {
        private static List<Table> _tables = new List<Table>
        {
            new Table { Id = 1, Name = "Table1" },
            new Table { Id = 2, Name = "Table2" }
        };

        // GET: /Tables/
        public IActionResult Index()
        {
            return View(_tables);
        }

        // GET: /Tables/Details/5
        public IActionResult Details(int id)
        {
            var table = _tables.FirstOrDefault(t => t.Id == id);
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
        public IActionResult Create(Table table)
        {
            if (ModelState.IsValid)
            {
                table.Id = _tables.Max(t => t.Id) + 1;
                _tables.Add(table);
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: /Tables/Edit/5
        public IActionResult Edit(int id)
        {
            var table = _tables.FirstOrDefault(t => t.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: /Tables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Table table)
        {
            if (ModelState.IsValid)
            {
                var existingTable = _tables.FirstOrDefault(t => t.Id == table.Id);
                if (existingTable == null)
                {
                    return NotFound();
                }
                existingTable.Name = table.Name;
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        // GET: /Tables/Delete/5
        public IActionResult Delete(int id)
        {
            var table = _tables.FirstOrDefault(t => t.Id == id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        // POST: /Tables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var table = _tables.FirstOrDefault(t => t.Id == id);
            if (table != null)
            {
                _tables.Remove(table);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
                                      