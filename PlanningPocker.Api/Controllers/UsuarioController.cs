using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Service.Interfaces;

namespace PlanningPocker.Api.Controllers
{
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : BaseController<Usuario>
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service): base(service)
        {
            _service = service;
        }
    }
}