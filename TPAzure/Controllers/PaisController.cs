using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using TPAzure.HttpServices;
using TPAzure.ViewModels;

namespace TPAzure.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisHttpService _paisHttpService;

        public PaisController(IPaisHttpService paisHttpService)
        {
            _paisHttpService = paisHttpService;
        }

        // GET: Pais
        public async Task<IActionResult> Index(string keySearch = null)
        {
            ViewBag.keySearch = keySearch;
            return View(await _paisHttpService.GetAllAsync(keySearch));
        }

        // GET: Pais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _paisHttpService.GetByIdAsync(id.Value);
              
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaisViewModel paisViewModel)
        {
            if (ModelState.IsValid)
            {
                await _paisHttpService.AddAsync(paisViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(paisViewModel);
        }

        // GET: Pais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _paisHttpService.GetByIdAsync(id.Value);
            if (paisViewModel == null)
            {
                return NotFound();
            }
            return View(paisViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  PaisViewModel paisViewModel)
        {
            if (id != paisViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _paisHttpService.EditAsync(paisViewModel);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisViewModelExists(paisViewModel.Id))
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
            return View(paisViewModel);
        }

        // GET: Pais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisViewModel = await _paisHttpService.GetByIdAsync(id.Value);
                
            if (paisViewModel == null)
            {
                return NotFound();
            }

            return View(paisViewModel);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paisViewModel = await _paisHttpService.GetByIdAsync(id);
            await _paisHttpService.RemoveAsync(paisViewModel);
           
            return RedirectToAction(nameof(Index));
        }

        private bool PaisViewModelExists(int id)
        {
            return _paisHttpService.GetByIdAsync(id) != null;
        }
    }
}
