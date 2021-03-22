using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Service.Interfaces;

namespace PlanningPocker.Api.Controllers
{
    public class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IServiceBase<TEntity> _service;

        public BaseController(IServiceBase<TEntity> service)
        {
            _service = service;
        }
        
        [HttpPost]
        public ActionResult<long> AddObj(TEntity obj){
            return _service.Create(obj);
        }
        
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TEntity> GetObjById(long id)
        {
            if (ModelState.IsValid)
            {
                var obj = _service.GetById(id);

                if (obj == null)
                    return NotFound("Registro não encontrado.");

                return obj;
            }
            else
                return BadRequest(ModelState);

        }

        [HttpGet]
        public ActionResult<List<TEntity>> GetAllObj()
        {
            var obj = _service.GetAll();            

            if (obj != null)
                return obj.ToList();
            else
                return NotFound("Não foram encontrados registros cadastrados.");

        }
   
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteObj(long id)
        {
            _service.Delete(id);

            if (ModelState.IsValid)
                return NotFound();
            else
                return BadRequest(ModelState);
        }

        [HttpPut]
        public ActionResult<TEntity> UpdateObj(
            [FromBody] TEntity obj
        )
        {
            if (ModelState.IsValid)
            {
                var oldObj = _service.GetById(obj.Id);
                if (oldObj != null)
                {                    
                    _service.Update(obj);
                    return obj;
                }
                else
                {
                    return NotFound("Registro não encontrado");
                }
            }
            else
                return BadRequest(ModelState);
        }
    }
}