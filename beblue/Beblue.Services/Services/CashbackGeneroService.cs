using Beblue.Domain.Entities;
using Beblue.Repositories.Interfaces;
using Beblue.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.Services.Services
{
    public class CashbackGeneroService : ServiceBase<CashbackGenero>, ICashbackGeneroService
    {
        /// <summary>
        /// Declaracao das interfaces
        /// </summary>
        private readonly ICashbackGeneroRepository _cashbackGeneroRepository;

        /// <summary>
        /// Método Construtor
        /// </summary>
        /// <param name="cashbackGeneroRepository"></param>
        public CashbackGeneroService(ICashbackGeneroRepository cashbackGeneroRepository) : base(cashbackGeneroRepository)
        {
            _cashbackGeneroRepository = cashbackGeneroRepository;
        }

        public void CleanTable()
        {
            var _dados = _cashbackGeneroRepository.GetAll();

            foreach (var item in _dados)
            {
                _cashbackGeneroRepository.Remove(item);
            }
        }

        public object Add(Genero genero)
        {
            List<CashbackGenero> _genero = new List<CashbackGenero>();

            switch (genero.Nome)
            {
                case "pop":
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 0, PercentualCashbackDia = 0.25 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 1, PercentualCashbackDia = 0.07 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 2, PercentualCashbackDia = 0.06 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 3, PercentualCashbackDia = 0.02 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 4, PercentualCashbackDia = 0.1 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 5, PercentualCashbackDia = 0.15 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 6, PercentualCashbackDia = 0.2 });
                                                                  
                    break;                                        
                case "mpb":                                       
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 0, PercentualCashbackDia = 0.3 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 1, PercentualCashbackDia = 0.05 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 2, PercentualCashbackDia = 0.1 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 3, PercentualCashbackDia = 0.15 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 4, PercentualCashbackDia = 0.2 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 5, PercentualCashbackDia = 0.25 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 6, PercentualCashbackDia = 0.3 });
                                                                  
                    break;                                        
                case "classical":                                 
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 0, PercentualCashbackDia = 0.35 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 1, PercentualCashbackDia = 0.03 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 2, PercentualCashbackDia = 0.05 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 3, PercentualCashbackDia = 0.08 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 4, PercentualCashbackDia = 0.13 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 5, PercentualCashbackDia = 0.18 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 6, PercentualCashbackDia = 0.25 });
                                                                  
                    break;                                        
                case "rock":                                      
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 0, PercentualCashbackDia = 0.4 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 1, PercentualCashbackDia = 0.1 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 2, PercentualCashbackDia = 0.15 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 3, PercentualCashbackDia = 0.15 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 4, PercentualCashbackDia = 0.15 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 5, PercentualCashbackDia = 0.2 });
                    _genero.Add(new CashbackGenero() { GeneroId = genero.Id, DiaSemana = 6, PercentualCashbackDia = 0.4 });

                    break;
                default:
                    break;
            }

            foreach (var item in _genero)
            {
                _cashbackGeneroRepository.Add(item);
            }

            var _cashbacks = _genero.Where(x => x.DiaSemana == (int)DateTime.Today.DayOfWeek).ToList();

            return 1;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
