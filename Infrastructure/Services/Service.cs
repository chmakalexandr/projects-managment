using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
       
        private readonly EFGenericRepository<TEntity> repository;
        private UnitOfWork unitOfWork;
        #region Constructor

        protected Service(EFGenericRepository<TEntity> repository)
        {
            unitOfWork = new UnitOfWork();
            _repository = repository;
        }
        #endregion Constructor

        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters) { return unitOfWork._repository.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(TEntity entity)
        {
            unitOfWork._repository.Insert(entity);
            unitOfWork.Save();
        }

        public virtual void Update(TEntity entity)
        {
            unitOfWork._repository.Update(entity);
            unitOfWork.Save();
        }

        public virtual void Delete(object id)
        {
            unitOfWork._repository.Delete(id);
            unitOfWork.Save();
        }

        public virtual void Delete(TEntity entity)
        {
            unitOfWork._repository.Remove(entity);
            unitOfWork.Save();
        }

        public virtual TEntity Find(string predicate)
        {
            return unitOfWork._repository.Find(predicate);
        }

        public virtual void Delete(int id)
        {
            unitOfWork._repository.Delete(id);
            unitOfWork.Save();
        }
    }
}
