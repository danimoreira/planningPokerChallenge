using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanningPocker.Domain.Entities;
using PlanningPocker.Repository.Context;
using PlanningPocker.Repository.Interfaces;

namespace PlanningPocker.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly PlanningPockerContext PlanningPockerContext;

        public RepositoryBase(PlanningPockerContext planningPockerContext)
        {
            PlanningPockerContext = planningPockerContext;
        }

        public long Add(TEntity obj)
        {
            var result = PlanningPockerContext.Add(obj);
            Save();
            return result.Entity.Id;
        }

        public void Delete(long id)
        {
            var obj = GetById(id);

            if (null != obj)
            {
                PlanningPockerContext.Remove(obj);
                Save();
            }
                
        }

        public System.Linq.IQueryable<TEntity> GetAll()
        {
            return PlanningPockerContext.Set<TEntity>();
        }

        public TEntity GetById(long id)
        {
            return GetAll().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Save()
        {
            PlanningPockerContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            PlanningPockerContext.Update(obj);
            Save();
        }
    }
}