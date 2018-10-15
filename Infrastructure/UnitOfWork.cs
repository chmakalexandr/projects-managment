using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Infrastructure.Data
{
    public class UnitOfWork : IDisposable
    {
        private PMContext context;

        public UnitOfWork()
        {
            context = new PMContext();
        }
        
        private Dictionary<Type,object> repositories = new Dictionary<Type, object>();
        public IGenericRepository<TEntity> EFGenericRepository<TEntity>() where TEntity: class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                    return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }
                   
            IGenericRepository<TEntity> repository = new EFGenericRepository<TEntity>(context);
            repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
