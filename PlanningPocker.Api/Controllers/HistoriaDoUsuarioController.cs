using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Service.Interfaces;

namespace PlanningPocker.Api.Controllers
{
    [ApiController]
    [Route("v1/historia")]
    public class HistoriaDoUsuarioController : BaseController<HistoriaDoUsuario>
    {
        private readonly IHistoriaDoUsuarioService _service;

        public HistoriaDoUsuarioController(IHistoriaDoUsuarioService service): base(service)
        {
            _service = service;
        }
    }
}