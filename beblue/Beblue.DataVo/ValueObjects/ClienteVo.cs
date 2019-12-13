using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Beblue.DataVo.ValueObjects
{
    [DataContract]
    public class ClienteVo 
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = false)]
        public string Id { get; set; } = "";

        [DataMember(Order = 2, Name = "Nome", IsRequired = true)]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O tamanho não atende ao permitido de 100 caracteres.")]
        public string Nome { get; set; }
    }
}
