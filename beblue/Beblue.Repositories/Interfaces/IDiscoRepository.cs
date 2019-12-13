using Beblue.Domain.Entities;
using System.Collections.Generic;

namespace Beblue.Repositories.Interfaces
{
    public interface IDiscoRepository : IRepositoryBase<Disco>
    {
        /// <summary>
        /// Retorna uma lista de pedidos por Genero e paginada
        /// </summary>
        /// <param name="pGenero"></param>
        /// <param name="pPage"></param>
        /// <param name="pLength"></param>
        /// <returns></returns>
        List<Disco> GetAll(string pGenero, int pPage, int pLength);
    }
}
