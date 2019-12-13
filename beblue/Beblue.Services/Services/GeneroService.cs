using Beblue.DataVo.Converters;
using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;
using System.Linq;

namespace Beblue.Services.Services
{
    public class GeneroService : ServiceBase<Genero>, IGeneroService
    {
        /// <summary>
        /// Declaracao das Interfaces
        /// </summary>
        private readonly IGeneroRepository _generoRepository;
        private readonly ICashbackGeneroService _cashbackGeneroService;
        private readonly GeneroConverter _generoConverter;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="generoRepository"></param>
        public GeneroService(IGeneroRepository generoRepository,
                             ICashbackGeneroService cashbackGeneroService,
                             GeneroConverter generoConverter) : base(generoRepository)
        {
            _generoRepository = generoRepository;
            _cashbackGeneroService = cashbackGeneroService;
            _generoConverter = generoConverter;
        }

        public new Genero Add(Genero genero)
        {
            if (_generoRepository.GetAll().Where(x => x.Nome == genero.Nome).Count() == 0)
            {
                var generoid = _generoRepository.Add(genero);

                _cashbackGeneroService.Add(generoid);
            }

            return genero;
        }

        public void CleanTable()
        {
            var _dados = _generoRepository.GetAll();

            foreach (var item in _dados)
            {
                _generoRepository.Remove(item);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
