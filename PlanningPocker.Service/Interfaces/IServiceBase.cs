using System.Collections.Generic;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Service.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetAll();        
        TEntity GetById(long id);
        void Delete(long id);
        long Create(TEntity obj);
        void Update(TEntity obj);
    }
}