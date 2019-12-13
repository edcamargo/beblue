using Beblue.Domain.Entities;
using Beblue.Repositories.Context;
using Beblue.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Repositories.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="context"></param>
        public PedidoRepository(BeblueContext context) : base(context)
        { }

        public List<Pedido> GetAll(DateTime? DataInicial = null, DateTime? DataFinal = null, int Page = 1, int Length = 1)
        {
            using (var db = new BeblueContext())
            {
                /* 
                 * Seleciona apanas os pedidos com os critérios desejadas.
                */
                var lQuery = (from Pedido in db.Pedido.AsNoTracking()
                               join Cliente in db.Cliente.AsNoTracking()
                                     on Pedido.ClienteId equals Cliente.Id
                               where Pedido.DataVenda >= DataInicial
                                  && Pedido.DataVenda <= DataFinal

                               orderby Pedido.DataVenda descending
                               select new Pedido
                               {
                                   Id = Pedido.Id,
                                   DataVenda = Pedido.DataVenda,
                                   TotalVenda = Pedido.TotalVenda,
                                   ValorCashback = Pedido.ValorCashback,
                                   ClienteId = Pedido.ClienteId,
                                   Cliente = Cliente,
                                   PedidoItens = Pedido.PedidoItens
                               }).Skip((Page - 1) * Length).Take(Length).ToList();

                return lQuery;
            }
        }

        public List<Pedido> GetId(string Id)
        {
            using (var db = new BeblueContext())
            {
                /* 
                 * Seleciona apanas os pedidos com os critérios desejadas.
                */
                var lQuery = (from Pedido in db.Pedido.AsNoTracking()
                              join Cliente in db.Cliente.AsNoTracking()
                                    on Pedido.ClienteId equals Cliente.Id
                              where Pedido.Id == Id
                              orderby Pedido.DataVenda descending
                              select new Pedido
                              {
                                  Id = Pedido.Id,
                                  DataVenda = Pedido.DataVenda,
                                  TotalVenda = Pedido.TotalVenda,
                                  ValorCashback = Pedido.ValorCashback,
                                  ClienteId = Pedido.ClienteId,
                                  Cliente = Cliente,
                                  PedidoItens = Pedido.PedidoItens
                              }).ToList();

                return lQuery;
            }
        }
    }
}
