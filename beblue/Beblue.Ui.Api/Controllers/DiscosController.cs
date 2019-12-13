using System;
using System.Collections.Generic;
using Beblue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beblue.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DiscosController : ControllerBase
    {
        private readonly IDiscoService _discoService;

        public DiscosController(IDiscoService discoService)
        {
            _discoService = discoService;
        }

        [HttpGet("Genero/{Genero}/Page/{Page}/Length/{Length}")]
        public ActionResult<IEnumerable<string>> Get(string Genero, int Page, int Length)
        {
            try
            {
                var registros = _discoService.GetAll(Genero, Page, Length);
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
                var registros = _discoService.GetById(Id);
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
    }
}
