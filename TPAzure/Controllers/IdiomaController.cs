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
        private readonly IPaisAppService _paisAppService;

        public IdiomaController(IIdiomaAppService idiomaAppService, IPaisAppService paisAppService)
        {
            _idiomaAppService = idiomaAppService;
            _paisAppService = paisAppService;
        }

     
        public async Task<IActionResult> Index()
        {
            await PopulateSelectedPaises();
            return View(await _idiomaAppService.GetAllAsync(null));
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaViewModel = await _idiomaAppService.GetByIdAsync(id.Value);

            if (idiomaViewModel == null)
            {
                return NotFound();
            }
            var pais = await _paisAppService.GetByIdAsync(idiomaViewModel.PaisId);
            if(pais.Id == idiomaViewModel.PaisId)
            {
                idiomaViewModel.Pais = pais;
            }
            
            return View(idiomaViewModel);
        }

  
        public async Task<IActionResult> Create()
        {
            await PopulateSelectedPaises();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdiomaViewModel idiomaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _idiomaAppService.AddAsync(idiomaViewModel);
                return RedirectToAction(nameof(Index));
            }
            await PopulateSelectedPaises(idiomaViewModel.PaisId);
            return View(idiomaViewModel);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaViewModel = await _idiomaAppService.GetByIdAsync(id.Value);
            
            if (idiomaViewModel == null)
            {
                return NotFound();
            }

            await PopulateSelectedPaises();
            return View(idiomaViewModel);
        }

 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IdiomaViewModel idiomaViewModel)
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
                    if (!IdiomaViewModelExists(idiomaViewModel.Id))
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
            await PopulateSelectedPaises(idiomaViewModel.PaisId);
            return View(idiomaViewModel);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaViewModel = await _idiomaAppService.GetByIdAsync(id.Value);

            if (idiomaViewModel == null)
            {
                return NotFound();
            }
            var pais = await _paisAppService.GetByIdAsync(idiomaViewModel.PaisId);
            if (pais.Id == idiomaViewModel.PaisId)
            {
                idiomaViewModel.Pais = pais;
            }

            return View(idiomaViewModel);
        }

        // POST: Pais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomaViewModel = await _idiomaAppService.GetByIdAsync(id);
            await _idiomaAppService.RemoveAsync(idiomaViewModel);

            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaViewModelExists(int id)
        {
            return _idiomaAppService.GetByIdAsync(id) != null;
        }


        //Métodos auxiliares
        private async Task PopulateSelectedPaises(int? paisId = null)
        {
            var paises = await _paisAppService.GetAllAsync(null);
            ViewBag.Paises = new SelectList(paises, nameof(PaisViewModel.Id),
                nameof(PaisViewModel.Nome),
                paisId); 
        }

    }
}
