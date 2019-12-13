using Beblue.Domain.Entities;

namespace Beblue.Services.Interfaces
{
    public interface ICashbackGeneroService : IServiceBase<CashbackGenero>
    {
        /// <summary>
        /// Adicionar novo registro
        /// </summary>
        /// <param name="genero"></param>
        /// <returns></returns>
        object Add(Genero genero);

        /// <summary>
        /// Limpa registros da tabela
        /// </summary>
        void CleanTable();
    }
}
