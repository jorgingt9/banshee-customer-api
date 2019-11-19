using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Exceptions;
using Banshee.Customers.Domain.Interfaces;
using Banshee.Customers.Dto;
using Banshee.Customers.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banshee.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Obtiene la lista de clientes
        /// </summary>
        /// <returns>Lista de clientes</returns>
        /// <response code="200">Listado de clientes</response>
        /// <response code="400">No se ha encontrado la lista de clientes</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Customer>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _customerService.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Obtiene un cliente por id
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <returns></returns>
        /// <response code="200">Cliente correspondiente al Id ingresado</response>
        /// <response code="400">No se ha encontrado el vendedor para el id ingresado. Id inválido</response>
        /// <response code="404">Error al invocar servicio</response>
        [HttpGet("id", Name = "GetCustomer")]
        [ProducesResponseType(typeof(Customer), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _customerService.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "CP500", Message = e.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo Cliente
        /// </summary>
        /// <param name="value">Customer</param>
        /// <returns>bool - True: Crea el cliente - False: No actualizo el cliente</returns>
        /// <response code="200">Cliente creado</response>
        /// <response code="400">No se crea el cliente</response>
        /// <response code="404">Error al invocar servicio</response> 
        [ValidateModelAttribute]
        [HttpPost]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Post([FromBody] Customer value)
        {
            try
            {


                return Ok(await _customerService.Save(value));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "P500", Message = e.Message });
            }
        }

        /// <summary>
        /// Actualiza un elemento de tipo Customer
        /// </summary>
        /// <param name="id">id del cliente</param>
        /// <param name="value">Entidad cliente</param>
        /// <returns>bool - True: Actualiza el cliente - False: No actualizo el cliente</returns>
        /// <response code="200">Cliente actualizado</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="404">Error al invocar servicio</response> 
        [ValidateModelAttribute]
        [HttpPut]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Put(int id, [FromBody] Customer value)
        {
            try
            {
                var customer = await _customerService.ValidateCustomer(id);
                value.Id = id;

                return Ok(await _customerService.Update(value));
            }
            catch (CustomerNotFoundException e)
            {
                return NotFound(new ErrorResponseDto() { Code = "U404", Message = e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "P500", Message = e.Message});
            }
        }

        /// <summary>
        /// Elimina un elemento de tipo Customer
        /// </summary>
        /// <param name="value">Id del cliente a eliminar</param>
        /// <returns>bool - True: Elimina Cliente - False: No elimina Cliente</returns>
        /// <response code="200">Cliente eliminado</response>
        /// <response code="400">Product has missing/invalid values</response>
        /// <response code="404">Error al invocar servicio</response> 
        [HttpDelete("id")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 404)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                return Ok(await _customerService.Delete(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, new ErrorResponseDto() { Code = "P500", Message = e.Message });
            }
        }
    }
}