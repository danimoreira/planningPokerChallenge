using System.ComponentModel.DataAnnotations.Schema;

namespace PlanningPocker.Domain.Entities
{
    [Table("Usuario")]
    public class Voto : BaseEntity
    {
        public long IdUsuario { get; set; }
        
        public virtual Usuario Usuario { get; set; }

        public long IdCarta { get; set; }
        public virtual Carta Carta { get; set; }

        public long IdHistoriaDoUsuario { get; set; }        
        public virtual HistoriaDoUsuario HistoriaDoUsuario { get; set; }
    }
}