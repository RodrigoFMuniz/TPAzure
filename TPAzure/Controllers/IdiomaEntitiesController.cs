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
    public class IdiomaEntitiesController : Controller
    {
        private readonly TPAzureContext _context;

        public IdiomaEntitiesController(TPAzureContext context)
        {
            _context = context;
        }

        // GET: IdiomaEntities
        public async Task<IActionResult> Index()
        {
            var tPAzureContext = _context.IdiomaEntity.Include(i => i.Pais);
            return View(await tPAzureContext.ToListAsync());
        }

        // GET: IdiomaEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaEntity = await _context.IdiomaEntity
                .Include(i => i.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaEntity == null)
            {
                return NotFound();
            }

            return View(idiomaEntity);
        }

        // GET: IdiomaEntities/Create
        public IActionResult Create()
        {
            ViewData["PaisId"] = new SelectList(_context.PaisEntity, "Id", "Id");
            return View();
        }

        // POST: IdiomaEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeIdioma,PaisId")] IdiomaEntity idiomaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idiomaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaisId"] = new SelectList(_context.PaisEntity, "Id", "Id", idiomaEntity.PaisId);
            return View(idiomaEntity);
        }

        // GET: IdiomaEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaEntity = await _context.IdiomaEntity.FindAsync(id);
            if (idiomaEntity == null)
            {
                return NotFound();
            }
            ViewData["PaisId"] = new SelectList(_context.PaisEntity, "Id", "Id", idiomaEntity.PaisId);
            return View(idiomaEntity);
        }

        // POST: IdiomaEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeIdioma,PaisId")] IdiomaEntity idiomaEntity)
        {
            if (id != idiomaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idiomaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdiomaEntityExists(idiomaEntity.Id))
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
            ViewData["PaisId"] = new SelectList(_context.PaisEntity, "Id", "Id", idiomaEntity.PaisId);
            return View(idiomaEntity);
        }

        // GET: IdiomaEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaEntity = await _context.IdiomaEntity
                .Include(i => i.Pais)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (idiomaEntity == null)
            {
                return NotFound();
            }

            return View(idiomaEntity);
        }

        // POST: IdiomaEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomaEntity = await _context.IdiomaEntity.FindAsync(id);
            _context.IdiomaEntity.Remove(idiomaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaEntityExists(int id)
        {
            return _context.IdiomaEntity.Any(e => e.Id == id);
        }
    }
}
