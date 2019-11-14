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
    public class SellersController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        public SellersController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        /// <summary>
        /// Obtiene la lista de vendedores
        /// </summary>
        /// <returns>Lista de vendedores</returns>
        /// <response code="200">Listado de vendedores</response>
        /// <response code="400">No se ha encontrado la lista de vendedores</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Seller>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _sellerService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene un vendedor por id
        /// </summary>
        /// <param name="id">id del vendedor</param>
        /// <returns></returns>
        /// <response code="200">Vendedor correspondiente al Id ingresado</response>
        /// <response code="400">No se ha encontrado el vendedor para el id ingresado. Id inválido</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet("id", Name ="GetSeller")]
        [ProducesResponseType(typeof(Seller), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _sellerService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }
    }
}