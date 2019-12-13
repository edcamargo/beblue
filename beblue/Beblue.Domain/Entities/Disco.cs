using Beblue.Domain.Entities.NotMapped;

namespace Beblue.Domain.Entities
{
    public class Disco : Entity
    {
        public virtual string GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
        public string Name { get; set; }
        public double Preco { get; set; }
    }
}
