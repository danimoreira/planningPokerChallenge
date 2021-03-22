using System.Collections.Generic;

namespace PlanningPocker.Domain.Entities
{
    public class Usuario : BaseEntity
    {         
        public string Nome { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}