using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System;

namespace Beblue.Services.Interfaces
{
    public interface IPedidoService : IServiceBase<Pedido>
    {
        /// <summary>
        /// Retorna todos os pedidos com parametro de data e paginacao
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="Page"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        object GetAll(DateTime? DataInicial, DateTime? DataFinal, int Page, int Length);

        /// <summary>
        /// Adiciona novo registro
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        object Add(PedidoVo pedido);

        /// <summary>
        /// Limpa registros da tabela
        /// </summary>
        void CleanTable();

        /// <summary>
        /// Retorna os pedidos por Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        object GetById(string Id);
    }
}
