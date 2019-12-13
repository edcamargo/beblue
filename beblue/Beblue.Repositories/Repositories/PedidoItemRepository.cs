using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;

namespace Beblue.Repositories.Repositories
{
    public class PedidoItemRepository : RepositoryBase<PedidoItem>, IPedidoItemRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public PedidoItemRepository(BeblueContext context) : base(context)
        { }
    }

}
