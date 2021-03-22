using System.ComponentModel.DataAnnotations;

namespace PlanningPocker.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            
        }
        
        public long Id { get; set; }
    }
}