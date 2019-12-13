using System;
using System.Collections.Generic;
using System.Web.Http;
using Beblue.DataVo.Converters;
using Beblue.DataVo.ValueObjects;
using Beblue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beblue.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        /// <summary>
        /// Declaracao de Interface
        /// </summary>
        private readonly IClienteService _clienteService;
        private readonly ClienteConverter _clienteConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="clienteService"></param>
        public ClientesController(IClienteService clienteService,
                                  ClienteConverter clienteConverter)
        {
            _clienteService = clienteService;
            _clienteConverter = clienteConverter;
        }

        [HttpGet()]
        public ActionResult<string> Get()
        {
            try
            {
                var registros = _clienteService.GetAll();
                return new OkObjectResult(registros);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<string>> Get(string Id)
        {
            try
            {
                var registros = _clienteService.GetById(Id);
                return new OkObjectResult(registros);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteVo cliente)
        {
            try
            {
                var clienteEntity = _clienteConverter.Parse(cliente);
                clienteEntity.Id = Guid.NewGuid().ToString();

                if (clienteEntity == null) return BadRequest();
                var ret = _clienteService.Add(clienteEntity);
                
                return Ok(ret);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        [HttpPut("{Id}")]
        public IActionResult Put([FromBody] ClienteVo cliente, string Id)
        {
            try
            {
                if (Id != cliente.Id) return BadRequest();

                var clienteEntity = _clienteConverter.Parse(cliente);

                _clienteService.Update(clienteEntity);
                return Ok(cliente);
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " | " + e.InnerException.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromUri] string[] Id)
        {
            try
            {
                foreach (var i in Id)
                {
                    var Atualizar = _clienteService.GetById(i);

                    if (Atualizar != null)
                    {
                        _clienteService.Remove(Atualizar);
                    }
                }

                return Ok();
            }
            catch (ArgumentNullException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
