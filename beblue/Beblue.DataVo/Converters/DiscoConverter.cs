using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.DataVo.Converters
{
    public class DiscoConverter : IParser<DiscoVo, Disco>, IParser<Disco, DiscoVo>
    {
        private GeneroConverter _generoConverter = new GeneroConverter();

        public Disco Parse(DiscoVo origin)
        {
            if (origin == null) return new Disco();
            return new Disco
            {
                Id = origin.Id,
                Name = origin.Name,
                Preco = origin.Preco,
                GeneroId = origin.Id
            };
        }

        public DiscoVo Parse(Disco origin)
        {
            if (origin == null) return new DiscoVo();
            return new DiscoVo
            {
                Id = origin.Id,
                Name = origin.Name,
                Preco = origin.Preco,
                Genero = _generoConverter.Parse(origin.Genero)
            };
        }

        public List<Disco> ParseList(List<DiscoVo> origin)
        {
            if (origin == null) return new List<Disco>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<DiscoVo> ParseList(List<Disco> origin)
        {
            if (origin == null) return new List<DiscoVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
