using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TPAzure.Data;
using TPAzure.Models;

namespace TPAzure.Controllers
{
    public class PaisEntitiesController : Controller
    {
        private readonly TPAzureContext _context;

        public PaisEntitiesController(TPAzureContext context)
        {
            _context = context;
        }

        // GET: PaisEntities
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaisEntity.ToListAsync());
        }

        // GET: PaisEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisEntity = await _context.PaisEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paisEntity == null)
            {
                return NotFound();
            }

            return View(paisEntity);
        }

        // GET: PaisEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaisEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataIndependencia,QtdHabitantes,ImageUri")] PaisEntity paisEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paisEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paisEntity);
        }

        // GET: PaisEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisEntity = await _context.PaisEntity.FindAsync(id);
            if (paisEntity == null)
            {
                return NotFound();
            }
            return View(paisEntity);
        }

        // POST: PaisEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataIndependencia,QtdHabitantes,ImageUri")] PaisEntity paisEntity)
        {
            if (id != paisEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paisEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisEntityExists(paisEntity.Id))
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
            return View(paisEntity);
        }

        // GET: PaisEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisEntity = await _context.PaisEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paisEntity == null)
            {
                return NotFound();
            }

            return View(paisEntity);
        }

        // POST: PaisEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paisEntity = await _context.PaisEntity.FindAsync(id);
            _context.PaisEntity.Remove(paisEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisEntityExists(int id)
        {
            return _context.PaisEntity.Any(e => e.Id == id);
        }
    }
}
