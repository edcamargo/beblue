using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;

namespace Beblue.Repositories.Repositories
{
    public class GeneroRepository : RepositoryBase<Genero>, IGeneroRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public GeneroRepository(BeblueContext context) : base(context)
        { }
    }
}
