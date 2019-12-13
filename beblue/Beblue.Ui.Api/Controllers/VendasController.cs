using System;
using System.Collections.Generic;
using Beblue.DataVo.ValueObjects;
using Beblue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beblue.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public VendasController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<string>> Get(string Id)
        {
            try
            {
                var registros = _pedidoService.GetById(Id);
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

        /// <summary>
        /// Retorna todos pedidos - padrao de data: 2019-12-13 00:00:00
        /// </summary>
        /// <returns></returns>
        [HttpGet("DataInicial/{DataInicial}/DataFinal/{DataFinal}/Page/{Page}/Length/{Length}")]
        public ActionResult<IEnumerable<string>> Get(DateTime? DataInicial, DateTime? DataFinal, int Page, int Length)
        {
            try
            {
                var registros = _pedidoService.GetAll(DataInicial, DataFinal, Page, Length);
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
        public IActionResult Post([FromBody] PedidoVo pedido)
        {
            try
            {
                var pedidoEntity = pedido;
                if (pedidoEntity == null) return BadRequest();

                var retpedido = _pedidoService.Add(pedidoEntity);

                return Ok(retpedido);
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
    }
}
