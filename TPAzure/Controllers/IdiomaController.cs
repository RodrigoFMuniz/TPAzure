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
    public class IdiomaController : Controller
    {
        private readonly IIdiomaHttpService _idiomaHttpService;
        private readonly IPaisHttpService _paisHttpService;

        public IdiomaController(IIdiomaHttpService idiomaHttpService, IPaisHttpService paisHttpService)
        {
            _idiomaHttpService = idiomaHttpService;
            _paisHttpService = paisHttpService;
        }
 
        public async Task<IActionResult> Index(string keySearch = null)
        {
            ViewBag.keySearch = keySearch;
            //await PopulateSelectedPaises();

            var idiomas = await _idiomaHttpService.GetAllAsync(keySearch);
            await PopulateIdiomaWithPais(idiomas);

            return View(idiomas);
            //return View(await _idiomaHttpService.GetAllAsync(keySearch));
        }
    
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idiomaViewModel = await _idiomaHttpService.GetByIdAsync(id.Value);

            if (idiomaViewModel == null)
            {
                return NotFound();
            }
            var pais = await _paisHttpService.GetByIdAsync(idiomaViewModel.PaisId);
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdiomaViewModel idiomaViewModel)
        {
            if (ModelState.IsValid)
            {
                await _idiomaHttpService.AddAsync(idiomaViewModel);
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

            var idiomaViewModel = await _idiomaHttpService.GetByIdAsync(id.Value);
            
            if (idiomaViewModel == null)
            {
                return NotFound();
            }

            await PopulateSelectedPaises();
            return View(idiomaViewModel);
        }

        [Authorize]
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
                    await _idiomaHttpService.EditAsync(idiomaViewModel);

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

            var idiomaViewModel = await _idiomaHttpService.GetByIdAsync(id.Value);

            if (idiomaViewModel == null)
            {
                return NotFound();
            }
            var pais = await _paisHttpService.GetByIdAsync(idiomaViewModel.PaisId);
            if (pais.Id == idiomaViewModel.PaisId)
            {
                idiomaViewModel.Pais = pais;
            }

            return View(idiomaViewModel);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var idiomaViewModel = await _idiomaHttpService.GetByIdAsync(id);
            await _idiomaHttpService.RemoveAsync(idiomaViewModel);

            return RedirectToAction(nameof(Index));
        }

        private bool IdiomaViewModelExists(int id)
        {
            return _idiomaHttpService.GetByIdAsync(id) != null;
        }

        private async Task PopulateSelectedPaises(int? paisId = null)
        {
            var paises = await _paisHttpService.GetAllAsync(null);
            ViewBag.Paises = new SelectList(paises, nameof(PaisViewModel.Id),
                nameof(PaisViewModel.Nome),
                paisId); 
        }

        private async Task PopulateIdiomaWithPais(IEnumerable<IdiomaViewModel> idiomas)
        {
            foreach(var idioma in idiomas)
            {
                var pais = await _paisHttpService.GetByIdAsync(idioma.PaisId);
                if (pais.Id == idioma.PaisId)
                {
                    idioma.Pais = pais;
                }
            }
            
        }
    }
}
