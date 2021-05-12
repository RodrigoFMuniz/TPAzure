using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.ViewModels;
using Application.AppServices;

namespace TPAzure.Controllers
{
    public class IdiomaController : Controller
    {
        private readonly IIdiomaAppService _idiomaAppService;

        public IdiomaController(IIdiomaAppService idiomaAppService)
        {
            _idiomaAppService = idiomaAppService;
        }

        // GET: Pais
        public async Task<IActionResult> Index()
        {
            return View(await _idiomaAppService.GetAllAsync(null));
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _idiomaAppService.GetByIdAsync(id.Value);

            if (paisViewModel == null)
            {
                return NotFound();
            }

            return View(paisViewModel);
        }

        // GET: Pais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataIndependencia,QtdHabitantes,ImageUri")] IdiomaViewModel idiomaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _idiomaAppService.AddAsync(idiomaViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(idiomaViewModel);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _idiomaAppService.GetByIdAsync(id.Value);
            if (paisViewModel == null)
            {
                return NotFound();
            }
            return View(paisViewModel);
        }

        // POST: Pais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataIndependencia,QtdHabitantes,ImageUri")] IdiomaViewModel idiomaViewModel)
        {
            if (id != idiomaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _idiomaAppService.EditAsync(idiomaViewModel);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisViewModelExists(idiomaViewModel.Id))
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
            return View(idiomaViewModel);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _idiomaAppService.GetByIdAsync(id.Value);

            if (paisViewModel == null)
            {
                return NotFound();
            }

            return View(paisViewModel);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paisViewModel = await _idiomaAppService.GetByIdAsync(id);
            await _idiomaAppService.RemoveAsync(paisViewModel);

            return RedirectToAction(nameof(Index));
        }

        private bool PaisViewModelExists(int id)
        {
            return _idiomaAppService.GetByIdAsync(id) != null;
        }
    }
}
