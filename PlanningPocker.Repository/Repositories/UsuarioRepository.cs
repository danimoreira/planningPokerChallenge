using PlanningPocker.Domain.Entities;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;

namespace PlanningPocker.Repository.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(PlanningPockerContext planningPockerContext) : base(planningPockerContext)
        {
            
        } 
    }
}