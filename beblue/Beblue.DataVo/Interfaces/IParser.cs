using System;
using System.Collections.Generic;
using System.Text;

namespace Beblue.DataVo.Interfaces
{
    /// <summary>
    /// Realiza o Parse de Object de Origin com o Object de Destino
    /// </summary>
    /// <typeparam name="O"></typeparam>
    /// <typeparam name="D"></typeparam>
    public interface IParser<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
