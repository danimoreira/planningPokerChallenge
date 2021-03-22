using System.Collections.Generic;
using System.Linq;
using PlanningPocker.Service.Interfaces;
using PlanningPocker.Repository.Interfaces;
using PlanningPocker.Domain.Entities;


namespace PlanningPocker.Service.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual long Create(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public virtual void Delete(long id)
        {
            _repository.Delete(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public virtual void Update(TEntity obj)
        {
             _repository.Update(obj);
        }
    }
}