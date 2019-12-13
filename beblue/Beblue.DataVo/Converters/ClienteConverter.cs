using System;
using System.Collections.Generic;
using System.Linq;
using Beblue.DataVo.Interfaces;
using Beblue.DataVo.ValueObjects;
using Beblue.Domain.Entities;

namespace Beblue.DataVo.Converters
{
    public class ClienteConverter : IParser<ClienteVo, Cliente>, IParser<Cliente, ClienteVo>
    {
        public Cliente Parse(ClienteVo origin)
        {
            if (origin == null) return new Cliente();
            return new Cliente
            {
                Id = origin.Id,
                Nome = origin.Nome
            };
        }

        public ClienteVo Parse(Cliente origin)
        {
            if (origin == null) return new ClienteVo();
            return new ClienteVo
            {
                Id = origin.Id,
                Nome = origin.Nome
            };
        }

        public List<Cliente> ParseList(List<ClienteVo> origin)
        {
            if (origin == null) return new List<Cliente>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<ClienteVo> ParseList(List<Cliente> origin)
        {
            if (origin == null) return new List<ClienteVo>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
