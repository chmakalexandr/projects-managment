using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        TEntity FindById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        TEntity Find(string predicate);
        
        void Insert(TEntity item);
        void Remove(TEntity item);
        void Update(TEntity item);
        IEnumerable<TEntity> SelectQuery(string query, object[] parameters);
    }
}
