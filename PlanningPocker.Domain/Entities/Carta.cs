using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPocker.Domain.Entities
{    
    public class Carta : BaseEntity
    {        
        public int ValorDaCarta { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}