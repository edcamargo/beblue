using System.Runtime.Serialization;

namespace Beblue.DataVo.ValueObjects
{
    [DataContract]
    public class CashbackGeneroVo 
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = true)]
        public string Id { get; set; }

        [DataMember(Order = 2, Name = "GeneroId", IsRequired = true)]
        public string GeneroId { get; set; }

        [DataMember(Order = 3, Name = "Genero", IsRequired = true)]
        public GeneroVo Genero { get; set; }

        [DataMember(Order = 4, Name = "DiaSemana", IsRequired = true)]
        public int DiaSemana { get; set; }

        [DataMember(Order = 5, Name = "PercentualCashbackDia", IsRequired = true)]
        public double PercentualCashbackDia { get; set; }
    }
}
