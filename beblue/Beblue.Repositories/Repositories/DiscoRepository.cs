using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Repositories.Repositories
{
    public class DiscoRepository : RepositoryBase<Disco>, IDiscoRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public DiscoRepository(BeblueContext context) : base(context)
        { }

        /// <summary>
        /// Retorna uma lista de pedidos por Genero e paginada
        /// </summary>
        /// <param name="pGenero"></param>
        /// <param name="pPage"></param>
        /// <param name="pLength"></param>
        /// <returns></returns>
        public List<Disco> GetAll(string pGenero, int pPage, int pLength)
        {
            using (var db = new BeblueContext())
            {
                var lQuery = (from Disco in db.Disco
                              join Genero in db.Genero
                                    on Disco.GeneroId equals Genero.Id
                              where Genero.Nome.ToLower() == pGenero
                              orderby Disco.Name ascending
                              select new Disco {
                                  Id = Disco.Id,
                                  Name = Disco.Name,
                                  Preco = Disco.Preco,
                                  Genero = Genero,
                                  GeneroId = Disco.GeneroId
                              }).Skip((pPage - 1) * pLength).Take(pLength).ToList();

                return lQuery;
            }
        }
    }
}
