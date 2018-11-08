using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectsManagment.Data
{
    public class EFGenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity : class
    {
        protected PMContext _context;
        protected DbSet<TEntity> _dbSet;

        public EFGenericRepository(PMContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity Find(string predicate)
        {
            return _dbSet.Find(predicate);
        }

        public void Insert(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
           
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            
        }
        
        public void RemoveById(int id)
        {
            var item = _dbSet.Find(id);
            _dbSet.Remove(item);
            
        }

        public IEnumerable<TEntity> SelectQuery(string query, object[] parameters)
        {
           return _dbSet.SqlQuery(query, parameters);
        }
    }
}
