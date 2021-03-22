using PlanningPocker.Service.Interfaces;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Util.Messaging;

namespace PlanningPocker.Service.Services
{
    public class VotoService: ServiceBase<Voto>, IVotoService
    {
        private readonly IVotoRepository _repository;
        private readonly IUsuarioService _usuarioService;
        private readonly  IHistoriaDoUsuarioService _historiaDoUsuarioService;
        private readonly  ICartaService _cartaService;

        public VotoService(IVotoRepository repository, 
                            IUsuarioService usuarioService,
                            IHistoriaDoUsuarioService historiaDoUsuarioService,
                            ICartaService cartaService) : base(repository)
        {
            _repository = repository;
            _usuarioService = usuarioService;
            _historiaDoUsuarioService = historiaDoUsuarioService;
            _cartaService = cartaService;
        }

        public override long Create(Voto obj)
        {
            var result = base.Create(obj);

            ConfigurationRabbitMQ messageRabbit = new();

            var user = _usuarioService.GetById(obj.IdUsuario);
            var carta = _cartaService.GetById(obj.IdCarta);
            var historia = _historiaDoUsuarioService.GetById(obj.IdHistoriaDoUsuario);

            string message = string.Format("Usuário {0} votou na História {1} com a carta {2}",
                                            user.Nome, historia.Descricao, carta.ValorDaCarta.ToString()); 

            messageRabbit.SendMessage(message);

            return result;
        }

    }
}