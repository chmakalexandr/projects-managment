using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;

namespace ProjectsManagment.Data
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
       
        private UnitOfWork unitOfWork;

        #region Constructor
        protected Service()
        {
            unitOfWork = new UnitOfWork();
            
        }
        #endregion Constructor

        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters) { return unitOfWork.EFGenericRepository<TEntity>().SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(TEntity entity)
        {
            unitOfWork.EFGenericRepository<TEntity>().Insert(entity);
            unitOfWork.Save();
        }

        public virtual void Update(TEntity entity)
        {
            unitOfWork.EFGenericRepository<TEntity>().Update(entity);
            unitOfWork.Save();
        }
        
        public virtual void Delete(TEntity entity)
        {
            unitOfWork.EFGenericRepository<TEntity>().Remove(entity);
            unitOfWork.Save();
        }

        public TEntity FindById(int id)
        {
            return unitOfWork.EFGenericRepository<TEntity>().FindById(id);
        }

        public virtual TEntity Find(string predicate)
        {
            return unitOfWork.EFGenericRepository<TEntity>().Find(predicate);
        }
        
    }
}
