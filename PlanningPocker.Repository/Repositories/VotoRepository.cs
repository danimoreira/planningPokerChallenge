using PlanningPocker.Domain.Entities;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;

namespace PlanningPocker.Repository.Repositories
{
    public class VotoRepository : RepositoryBase<Voto>, IVotoRepository
    {
        public VotoRepository(PlanningPockerContext planningPockerContext) : base(planningPockerContext)
        {
            
        }
    }
}