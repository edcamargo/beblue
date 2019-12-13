using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Beblue.DataVo.Converters
{
    public class GeneroConverter : IParser<GeneroVo, Genero>, IParser<Genero, GeneroVo>
    {
        public Genero Parse(GeneroVo origin)
        {
            if (origin == null) return new Genero();
            return new Genero
            {
                Id = origin.Id,
                Nome = origin.Nome
            };
        }

        public GeneroVo Parse(Genero origin)
        {
            if (origin == null) return new GeneroVo();
            return new GeneroVo
            {
                Id = origin.Id,
                Nome = origin.Nome
            };
        }

        public List<Genero> ParseList(List<GeneroVo> origin)
        {
            if (origin == null) return new List<Genero>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<GeneroVo> ParseList(List<Genero> origin)
        {
            if (origin == null) return new List<GeneroVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
