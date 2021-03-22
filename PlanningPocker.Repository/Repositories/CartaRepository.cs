using PlanningPocker.Domain.Entities;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;

namespace PlanningPocker.Repository.Repositories
{
    public class CartaRepository : RepositoryBase<Carta>, ICartaRepository
    {
        public CartaRepository(PlanningPockerContext planningPockerContext) : base(planningPockerContext)
        {
            
        } 
    }
}