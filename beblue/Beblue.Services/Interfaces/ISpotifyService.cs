using Beblue.Domain.Entities;

namespace Beblue.Services.Interfaces
{
    public interface ISpotifyService : IServiceBase<Disco>
    {
        /// <summary>
        /// Gera a carga de dados da Api do Spotify
        /// </summary>
        /// <returns></returns>
        void GetAlbuns();
    }
}
