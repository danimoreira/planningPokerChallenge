using PlanningPocker.Domain.Entities;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;

namespace PlanningPocker.Repository.Repositories
{
    public class HistoriaDoUsuarioRepository : RepositoryBase<HistoriaDoUsuario>, IHistoriaDoUsuarioRepository
    {
        public HistoriaDoUsuarioRepository(PlanningPockerContext planningPockerContext) : base(planningPockerContext)
        {
        }
    }
}