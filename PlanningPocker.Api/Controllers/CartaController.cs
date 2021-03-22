using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Service.Interfaces;

namespace PlanningPocker.Api.Controllers
{
    [ApiController]
    [Route("v1/carta")]
    public class CartaController : BaseController<Carta>
    {
        private readonly ICartaService _service;

        public CartaController(ICartaService service) : base(service)
        {
            _service = service;
        }        
    }
}