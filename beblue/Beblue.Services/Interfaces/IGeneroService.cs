using Beblue.Domain.Entities;

namespace Beblue.Services.Interfaces
{
    public interface IGeneroService : IServiceBase<Genero>
    {
        /// <summary>
        /// Adiciona novo registro
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        new Genero Add(Genero genero);

        /// <summary>
        /// Limpa registros da tabela
        /// </summary>
        void CleanTable();
    }
}
