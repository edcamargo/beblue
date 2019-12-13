using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;

namespace Beblue.Services.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IClienteRepository _clienteRepository;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="clienteRepository"></param>
        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
