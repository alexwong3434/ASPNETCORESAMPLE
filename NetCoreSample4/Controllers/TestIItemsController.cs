using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreSample4.Data;
using NetCoreSample4.Models;

namespace NetCoreSample4.Controllers
{
    public class TestIItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestIItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestIItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestIItem.ToListAsync());
        }

        // GET: TestIItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testIItem = await _context.TestIItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testIItem == null)
            {
                return NotFound();
            }

            return View(testIItem);
        }

        // GET: TestIItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestIItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,imgsrc,Name,Price,Description")] TestIItem testIItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testIItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testIItem);
        }

        // GET: TestIItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testIItem = await _context.TestIItem.FindAsync(id);
            if (testIItem == null)
            {
                return NotFound();
            }
            return View(testIItem);
        }

        // POST: TestIItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,imgsrc,Name,Price,Description")] TestIItem testIItem)
        {
            if (id != testIItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testIItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestIItemExists(testIItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testIItem);
        }

        // GET: TestIItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testIItem = await _context.TestIItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testIItem == null)
            {
                return NotFound();
            }

            return View(testIItem);
        }

        // POST: TestIItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testIItem = await _context.TestIItem.FindAsync(id);
            _context.TestIItem.Remove(testIItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestIItemExists(int id)
        {
            return _context.TestIItem.Any(e => e.Id == id);
        }
    }
}
