using Beblue.Domain.Entities.NotMapped;
using System;

namespace Beblue.Domain.Entities
{
    public class CashbackGenero : Entity
    {
        public string GeneroId { get; set; }

        public Genero Genero { get; set; }

        public int DiaSemana { get; set; }

        public double PercentualCashbackDia { get; set; }
    }
}
