using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdiomaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IIdiomaService _idiomaService;
        public IdiomaController(IIdiomaService idiomaService, IMapper mapper)
        {
            _idiomaService = idiomaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdiomaViewModel>>> Get(string? search)
        {
            var idiomaEntities = await _idiomaService.GetAllAsync(search);
            return Ok(_mapper.Map<IEnumerable<IdiomaViewModel>>(idiomaEntities));
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<IdiomaViewModel>> Get(int id)
        {
            var idiomaEntity = await _idiomaService.GetByIdAsync(id);
            return Ok(_mapper.Map<IdiomaViewModel>(idiomaEntity));
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(IdiomaViewModel idiomaViewModel)
        {
            var idiomaEntity = _mapper.Map<IdiomaEntity>(idiomaViewModel);
            var id = await _idiomaService.AddAsync(idiomaEntity);
            return Ok(id);
        }
        [HttpPut]
        public async Task<ActionResult<int>> Put(IdiomaViewModel idiomaViewModel)
        {
            var paisNaoEncontrado = await _idiomaService.GetByIdAsync(idiomaViewModel.Id) is null;

            if (paisNaoEncontrado)
            {
                return NotFound();
            }

            var idiomaEntity = _mapper.Map<IdiomaEntity>(idiomaViewModel);
            await _idiomaService.EditAsync(idiomaEntity);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var idiomaEntity = await _idiomaService.GetByIdAsync(id);

            if (idiomaEntity is null)
            {
                return NotFound();
            }

            await _idiomaService.EditAsync(idiomaEntity);

            return Ok();
        }
    }
}
