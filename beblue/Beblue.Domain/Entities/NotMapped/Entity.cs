using System;
using System.ComponentModel.DataAnnotations;

namespace Beblue.Domain.Entities.NotMapped
{
    public class Entity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
