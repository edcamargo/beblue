using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beblue.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beblue.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CashbackGeneroController : ControllerBase
    {
        private readonly ICashbackGeneroService _cashbackGeneroService;

        public CashbackGeneroController(ICashbackGeneroService cashbackGeneroService)
        {
            _cashbackGeneroService = cashbackGeneroService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                var registros = _cashbackGeneroService.GetAll();
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
