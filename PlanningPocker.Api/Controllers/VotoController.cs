using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Service.Interfaces;

namespace PlanningPocker.Api.Controllers
{
    [ApiController]
    [Route("v1/voto")]
    public class VotoController : BaseController<Voto>
    {
        private readonly IVotoService _service;

        public VotoController(IVotoService service): base(service)
        {
            _service = service;
        }
    }
}