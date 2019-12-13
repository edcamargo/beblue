using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;

namespace Beblue.Repositories.Repositories
{
    public class CashbackGeneroRepository : RepositoryBase<CashbackGenero>, ICashbackGeneroRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public CashbackGeneroRepository(BeblueContext context) : base(context)
        { }
    }
}
