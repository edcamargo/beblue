using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;

namespace Beblue.Services.Interfaces
{
    public interface IDiscoService : IServiceBase<Disco>
    {
        /// <summary>
        /// Adicionar novo registro
        /// </summary>
        /// <param name="discoVo"></param>
        /// <returns></returns>
        DiscoVo Add(DiscoVo discoVo);

        /// <summary>
        /// Retorna uma listagem de disco por genero e paginacao
        /// </summary>
        /// <param name="Genero"></param>
        /// <param name="Page"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        object GetAll(string Genero, int Page, int Length);

        /// <summary>
        /// Limpa registros da tabela
        /// </summary>
        void CleanTable();
    }
}
