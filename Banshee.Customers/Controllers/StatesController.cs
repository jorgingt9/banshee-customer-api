using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using Banshee.Customers.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banshee.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;
        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        /// <summary>
        /// Obtiene la lista de estados
        /// </summary>
        /// <returns>Lista de estados</returns>
        /// <response code="200">Listado de estados</response>
        /// <response code="400">No se ha encontrado la lista de estados</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<State>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _stateService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene un estado por id
        /// </summary>
        /// <param name="id">id del estado</param>
        /// <returns></returns>
        /// <response code="200">Estado correspondiente al Id ingresado</response>
        /// <response code="400">No se ha encontrado el estado para el id ingresado. Id inválido</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet("{id}", Name = "GetState")]
        [ProducesResponseType(typeof(State), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _stateService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }
    }
}