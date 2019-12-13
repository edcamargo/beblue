using System.Runtime.Serialization;

namespace Beblue.DataVo.ValueObjects
{
    [DataContract]
    public class DiscoVo
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = true)]
        public virtual string Id { get; set; }

        [DataMember(Order = 2, Name = "Genero", IsRequired = true)]
        public GeneroVo Genero { get; set; }

        [DataMember(Order = 3, Name = "Name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Order = 4, Name = "Preco", IsRequired = true)]
        public double Preco { get; set; }
    }
}
