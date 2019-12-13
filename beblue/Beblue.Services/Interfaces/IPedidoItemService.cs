using Beblue.Domain.Entities;

namespace Beblue.Services.Interfaces
{
    public interface IPedidoItemService : IServiceBase<PedidoItem>
    {
        /// <summary>
        /// Limpa registros da tabela
        /// </summary>
        void CleanTable();
    }
}
