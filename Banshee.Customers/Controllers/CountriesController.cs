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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        /// <summary>
        /// Obtiene la lista de paises
        /// </summary>
        /// <returns>Lista de paises</returns>
        /// <response code="200">Listado de paises</response>
        /// <response code="400">No se ha encontrado la lista de paises</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Country>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _countryService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene un pais por id
        /// </summary>
        /// <param name="id">id del país</param>
        /// <returns></returns>
        /// <response code="200">País correspondiente al Id ingresado</response>
        /// <response code="400">No se ha encontrado el país para el id ingresado. Id inválido</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet("{id}", Name = "GetCountry")]
        [ProducesResponseType(typeof(Country), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _countryService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }
    }
}