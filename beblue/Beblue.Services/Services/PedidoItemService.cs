using Beblue.DataVo.Converters;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;

namespace Beblue.Services.Services
{
    public class PedidoItemService : ServiceBase<PedidoItem>, IPedidoItemService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly PedidoItemConverter _pedidoItemConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="pedidoItemRepository"></param>
        /// <param name="pedidoItemConverter"></param>
        public PedidoItemService(IPedidoItemRepository pedidoItemRepository,
                                 PedidoItemConverter pedidoItemConverter) : base(pedidoItemRepository)
        {
            _pedidoItemRepository = pedidoItemRepository;
            _pedidoItemConverter = pedidoItemConverter;
        }

        public void CleanTable()
        {
            var _dados = _pedidoItemRepository.GetAll();

            foreach (var item in _dados)
            {
                _pedidoItemRepository.Remove(item);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
