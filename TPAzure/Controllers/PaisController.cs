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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TPAzure.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisHttpService _paisHttpService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PaisController(IPaisHttpService paisHttpService, IWebHostEnvironment webHostEnvironment)
        {
            _paisHttpService = paisHttpService;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(ViewModelPaisIntermediario viewModelPaisIntermediario)
        {
            
            if (ModelState.IsValid)
            {
                var imgName = UploadedFile(viewModelPaisIntermediario);
                var paisViewModel = new PaisViewModel
                {
                    Id = viewModelPaisIntermediario.Id,
                    Nome = viewModelPaisIntermediario.Nome,
                    DataIndependencia = viewModelPaisIntermediario.DataIndependencia,
                    QtdHabitantes = viewModelPaisIntermediario.QtdHabitantes,
                    ImageUri = imgName
                };

                 
                await _paisHttpService.AddAsync(paisViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModelPaisIntermediario);
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

            var paisIntermediario = new ViewModelPaisIntermediario
            {
                Id = paisViewModel.Id,
                Nome = paisViewModel.Nome,
                DataIndependencia = paisViewModel.DataIndependencia,
                QtdHabitantes = paisViewModel.QtdHabitantes,
                ImageUri = null
            };

            return View(paisIntermediario);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ViewModelPaisIntermediario viewModelPaisIntermediario)
        {
            if (id != viewModelPaisIntermediario.Id)
            {
                return NotFound();
            }


            var paisViewModel = await _paisHttpService.GetByIdAsync(id);

            if (paisViewModel == null)
            {
                return NotFound();
            }

            var imgName = UploadedFile(viewModelPaisIntermediario);

            paisViewModel.Id = viewModelPaisIntermediario.Id;
            paisViewModel.Nome = viewModelPaisIntermediario.Nome;
            paisViewModel.DataIndependencia = viewModelPaisIntermediario.DataIndependencia;
            paisViewModel.QtdHabitantes = viewModelPaisIntermediario.QtdHabitantes;
            paisViewModel.ImageUri = imgName;
            if (imgName == null)
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
            RemoveFileFromStream(paisViewModel);
            await _paisHttpService.RemoveAsync(paisViewModel);
           
            return RedirectToAction(nameof(Index));
        }

        private bool PaisViewModelExists(int id)
        {
            return _paisHttpService.GetByIdAsync(id) != null;
        }

        private string UploadedFile(ViewModelPaisIntermediario paisViewModel)
        {
            string nomeUnicoArquivo = null;
            if (paisViewModel.ImageUri != null)
            {
                string pastaFotos = Path.Combine(_webHostEnvironment.WebRootPath,"Assets", "Imagens");

                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + paisViewModel.ImageUri.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    paisViewModel.ImageUri.CopyTo(fileStream);
                }
            }
            return nomeUnicoArquivo;
        }

        private void RemoveFileFromStream(PaisViewModel paisViewModel)
        {
           
            if (paisViewModel.ImageUri != null)
            {
                string pastaFotos =  Path.Combine(_webHostEnvironment.WebRootPath, "Assets", "Imagens");
                
                string caminhoArquivo = Path.Combine(pastaFotos, paisViewModel.ImageUri);

                if (System.IO.File.Exists(caminhoArquivo))
                {
                    System.IO.File.Delete(caminhoArquivo);
                }
            
            }
            
        }

    }
}
