using Beblue.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Beblue.Repositories.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        List<Pedido> GetAll(DateTime? DataInicial = null, DateTime? DataFinal = null, int Page = 1, int Length = 1);

        List<Pedido> GetId(string Id = "0");
    }
}
