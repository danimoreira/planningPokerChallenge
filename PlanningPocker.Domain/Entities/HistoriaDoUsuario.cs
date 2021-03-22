using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPocker.Domain.Entities
{    
    public class HistoriaDoUsuario : BaseEntity
    {        
        public string Descricao { get; set; }

        public ICollection<Voto> Votos { get; set; }
    }
}