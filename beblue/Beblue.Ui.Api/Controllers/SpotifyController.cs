using Beblue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Beblue.Ui.Api.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        /// <summary>
        /// Declaracao de Interface
        /// </summary>
        private readonly ISpotifyService _spotifyService;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="spotifyService"></param>
        public SpotifyController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet("CargaAlbum")]
        public IActionResult CargaAlbum()
        {
            _spotifyService.GetAlbuns();

            return Ok("Dados importados com sucesso!");
        }
    }
}
