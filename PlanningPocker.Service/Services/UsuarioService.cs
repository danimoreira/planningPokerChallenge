using PlanningPocker.Service.Interfaces;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Service.Services
{
    public class UsuarioService: ServiceBase<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _repository;        

        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}