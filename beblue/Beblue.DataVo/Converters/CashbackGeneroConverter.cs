using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.DataVo.Converters
{
    public class CashbackGeneroConverter : IParser<CashbackGeneroVo, CashbackGenero>, IParser<CashbackGenero, CashbackGeneroVo>
    {
        public CashbackGenero Parse(CashbackGeneroVo origin)
        {
            if (origin == null) return new CashbackGenero();
            return new CashbackGenero
            {
                Id = origin.Id,
                GeneroId = origin.GeneroId,
                DiaSemana = origin.DiaSemana,
                PercentualCashbackDia = origin.PercentualCashbackDia
            };
        }

        public CashbackGeneroVo Parse(CashbackGenero origin)
        {
            if (origin == null) return new CashbackGeneroVo();
            return new CashbackGeneroVo
            {
                Id = origin.Id,
                GeneroId = origin.GeneroId,
                DiaSemana = origin.DiaSemana,
                PercentualCashbackDia = origin.PercentualCashbackDia
            };
        }

        public List<CashbackGenero> ParseList(List<CashbackGeneroVo> origin)
        {
            if (origin == null) return new List<CashbackGenero>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<CashbackGeneroVo> ParseList(List<CashbackGenero> origin)
        {
            if (origin == null) return new List<CashbackGeneroVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
