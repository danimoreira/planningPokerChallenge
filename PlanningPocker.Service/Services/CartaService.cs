using PlanningPocker.Service.Interfaces;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Service.Services
{
    public class CartaService : ServiceBase<Carta>, ICartaService
    {
        private readonly ICartaRepository _repository;

        public CartaService(ICartaRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}