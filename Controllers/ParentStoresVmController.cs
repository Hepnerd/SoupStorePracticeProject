using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoupStorePracticeProject.Data;
using SoupStorePracticeProject.Models;

namespace SoupStorePracticeProject.Controllers
{
    public class ParentStoresControllerVm : Controller
    {
        private readonly ApplicationDbContext _context;

        List<Store> Store = new List<Store>();
        List<Cart> Cart = new List<Cart>();
        public ParentStoresControllerVm(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParentStores
        public async Task<IActionResult> IndexViewModel()
        {
            //ParentStoreVm model = new ParentStoreVm();
            //model.Stores = await _context.Store.ToListAsync();
            //model.Carts = await _context.Cart.ToListAsync();
            dynamic model = new ExpandoObject();
            model.Store = await _context.Store.ToListAsync();
            model.Cart = await _context.Cart.ToListAsync();
            //return View(await _context.ParentStore.ToListAsync());
            return View(model);
        }

        // GET: ParentStores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParentStore == null)
            {
                return NotFound();
            }

            var parentStore = await _context.ParentStore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentStore == null)
            {
                return NotFound();
            }

            return View(parentStore);
        }

        // GET: ParentStores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentStores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ParentStoreVm parentStore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parentStore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parentStore);
        }

        // GET: ParentStores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParentStore == null)
            {
                return NotFound();
            }

            var parentStore = await _context.ParentStore.FindAsync(id);
            if (parentStore == null)
            {
                return NotFound();
            }
            return View(parentStore);
        }

        // POST: ParentStores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ParentStoreVm parentStore)
        {
            if (id != parentStore.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parentStore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParentStoreExists(parentStore.Id))
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
            return View(parentStore);
        }

        // GET: ParentStores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParentStore == null)
            {
                return NotFound();
            }

            var parentStore = await _context.ParentStore
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parentStore == null)
            {
                return NotFound();
            }

            return View(parentStore);
        }

        // POST: ParentStores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParentStore == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ParentStore'  is null.");
            }
            var parentStore = await _context.ParentStore.FindAsync(id);
            if (parentStore != null)
            {
                _context.ParentStore.Remove(parentStore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParentStoreExists(int id)
        {
          return _context.ParentStore.Any(e => e.Id == id);
        }
    }
}
