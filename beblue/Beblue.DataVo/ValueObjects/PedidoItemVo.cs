using System.Runtime.Serialization;

namespace Beblue.DataVo.ValueObjects
{
    [DataContract]
    public class PedidoItemVo
    {
        public string PedidoId { get; set; }
        //public virtual PedidoVo Pedido { get; set; }

        [DataMember(Order = 1, Name = "DiscoId", IsRequired = true)]
        public string DiscoId { get; set; }
        public virtual DiscoVo Discos { get; set; }
    }
}
