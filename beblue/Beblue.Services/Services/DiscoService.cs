using Beblue.DataVo.Converters;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;
using System.Linq;

namespace Beblue.Services.Services
{
    public class DiscoService : ServiceBase<Disco>, IDiscoService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IDiscoRepository _discoRepository;
        private readonly DiscoConverter _discoConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="discoRepository"></param>
        public DiscoService(IDiscoRepository discoRepository,
                            DiscoConverter discoConverter) : base(discoRepository)
        {
            _discoRepository = discoRepository;
            _discoConverter = discoConverter;
        }

        public object GetAll(string Genero, int Page, int Length)
        {
            var disco = _discoRepository.GetAll(Genero, Page, Length);

            return _discoConverter.ParseList(disco);
        }

        public DiscoVo Add(DiscoVo discoVo)
        {
            var discoEntity = _discoConverter.Parse(discoVo);
            var disco = _discoRepository.Add(discoEntity);

            return _discoConverter.Parse(disco);
        }

        public void CleanTable()
        {
            var _dados = _discoRepository.GetAll();

            foreach (var item in _dados)
            {
                _discoRepository.Remove(item);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
