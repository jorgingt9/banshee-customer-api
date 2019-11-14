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
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        /// <summary>
        /// Obtiene la lista de ciudades
        /// </summary>
        /// <returns>Lista de ciudades</returns>
        /// <response code="200">Listado de ciudades</response>
        /// <response code="400">No se ha encontrado la lista de ciudades</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<City>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _cityService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene una ciudad por id
        /// </summary>
        /// <param name="id">id de la ciudad</param>
        /// <returns></returns>
        /// <response code="200">Ciudad correspondiente al Id ingresado</response>
        /// <response code="400">No se ha encontrado la ciudad para el id ingresado. Id inválido</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet("id",Name ="GetCity")]
        [ProducesResponseType(typeof(City), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _cityService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }
    }
}