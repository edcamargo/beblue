using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;

namespace Beblue.Repositories.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public ClienteRepository(BeblueContext context) : base(context)
        { }
    }
}
