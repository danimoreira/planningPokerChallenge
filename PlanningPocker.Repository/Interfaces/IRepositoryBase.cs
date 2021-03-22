using System.Linq;
using PlanningPocker.Domain.Entities;

namespace PlanningPocker.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        long Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(long id);
        void Save();
        IQueryable<TEntity> GetAll();
        TEntity GetById(long id);        
    }    
}