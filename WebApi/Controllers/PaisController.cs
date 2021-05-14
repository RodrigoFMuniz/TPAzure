using Domain.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.ViewModels;
using Domain.Model.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaisController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPaisService _paisService;
        public PaisController(IPaisService paisService, IMapper mapper)
        {
            _paisService = paisService;
            _mapper = mapper;
        }
        [HttpGet("{search?}")]
        public async Task<ActionResult<IEnumerable<PaisViewModel>>> Get(string? search) 
        {
            var paisEntities = await _paisService.GetAllAsync(search);
            return Ok(_mapper.Map<IEnumerable<PaisViewModel>> (paisEntities));
        }
        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<PaisViewModel>> Get([FromRoute] int id)
        {
            var paisEntity = await _paisService.GetByIdAsync(id);
            return Ok(_mapper.Map<PaisViewModel>(paisEntity));
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody]PaisViewModel paisViewModel) 
        {
            var paisEntity = _mapper.Map<PaisEntity>(paisViewModel);
            var id = await _paisService.AddAsync(paisEntity);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<int>> Put(int id, PaisViewModel paisViewModel)
        {
            if(id != paisViewModel.Id)
            {
                return BadRequest();
            }
            var paisNaoEncontrado = await _paisService.GetByIdAsync(paisViewModel.Id) is null;
            
            if (paisNaoEncontrado)
            {
                return NotFound();
            }

            var paisEntity = _mapper.Map<PaisEntity>(paisViewModel);
            await _paisService.EditAsync(paisEntity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var paisEntity = await _paisService.GetByIdAsync(id);

            if(paisEntity is null)
            {
                return NotFound();
            }

            await _paisService.RemoveAsync(paisEntity);

            return Ok();
        }

    }
}
