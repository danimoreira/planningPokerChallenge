using PlanningPocker.Service.Interfaces;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Service.Services
{
    public class HistoriaDoUsuarioService: ServiceBase<HistoriaDoUsuario>, IHistoriaDoUsuarioService
    {
        private readonly IHistoriaDoUsuarioRepository _repository;

        public HistoriaDoUsuarioService(IHistoriaDoUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}