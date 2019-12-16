using Beblue.DataVo.Converters;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;
using System.Linq;

namespace Beblue.Services.Services
{
    public class PedidoService : ServiceBase<Pedido>, IPedidoService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoItemRepository _pedidoItemRepository;
        private readonly IDiscoRepository _discoRepository;
        private readonly IGeneroRepository _generoRepository;
        private readonly ICashbackGeneroRepository _cashbackGeneroRepository;

        private readonly PedidoConverter _pedidoConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="pedidoRepository"></param>
        public PedidoService(IPedidoRepository pedidoRepository,
                             IPedidoItemRepository pedidoItemRepository,
                             IDiscoRepository discoRepository,
                             IGeneroRepository generoRepository,
                             ICashbackGeneroRepository cashbackGeneroRepository,
                             PedidoConverter pedidoConverter) : base(pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoItemRepository = pedidoItemRepository;
            _discoRepository = discoRepository;
            _generoRepository = generoRepository;
            _cashbackGeneroRepository = cashbackGeneroRepository;

            _pedidoConverter = pedidoConverter;
        }

        public object GetAll(DateTime? DataInicial, DateTime? DataFinal, int Page, int Length)
        {
            var pedidos = _pedidoRepository.GetAll(DataInicial, DataFinal, Page, Length);

            foreach (var item in pedidos)
            {
                item.PedidoItens = _pedidoItemRepository.GetAll().Where(x => x.PedidoId.Contains(item.Id)).ToList();

                foreach (var item2 in item.PedidoItens)
                {
                    item2.Discos = _discoRepository.GetById(item2.DiscoId);
                    item2.Discos.Genero = _generoRepository.GetById(item2.Discos.GeneroId);
                }
            }

            return pedidos;
        }

        public object Add(PedidoVo pedido)
        {
            var pedidoEntity = _pedidoConverter.Parse(pedido);

            // Verifica valor do disco comprado e calcula cashback
            foreach (var item in pedidoEntity.PedidoItens)
            {
                item.Discos = _discoRepository.GetById(item.DiscoId);

                var valorCashBack = _cashbackGeneroRepository.GetAll().Where(x => x.DiaSemana == (int)DateTime.Today.DayOfWeek && x.GeneroId == item.Discos.GeneroId).ToList();

                foreach (var item2 in valorCashBack)
                {
                    item.ValorCashBack = item.ValorCashBack + (item.Discos.Preco * item2.PercentualCashbackDia);
                }
            }

            // Soma total e totaliza venda
            pedidoEntity.TotalVenda = pedidoEntity.PedidoItens.Sum(x => x.Discos.Preco);
            pedidoEntity.ValorCashback = pedidoEntity.PedidoItens.Sum(x => x.ValorCashBack);

            var registro =  _pedidoRepository.Add(pedidoEntity);

            return _pedidoConverter.Parse(registro);
        }

        public void CleanTable()
        {
            var _dados = _pedidoRepository.GetAll();

            foreach (var item in _dados)
            {
                _pedidoRepository.Remove(item);
            }
        }

        public object GetById(string Id)
        {
            var pedidos = _pedidoRepository.GetId(Id);

            foreach (var item in pedidos)
            {
                item.PedidoItens = _pedidoItemRepository.GetAll().Where(x => x.PedidoId.Contains(item.Id)).ToList();

                foreach (var item2 in item.PedidoItens)
                {
                    item2.Discos = _discoRepository.GetById(item2.DiscoId);
                    item2.Discos.Genero = _generoRepository.GetById(item2.Discos.GeneroId);
                }
            }

            return pedidos;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
