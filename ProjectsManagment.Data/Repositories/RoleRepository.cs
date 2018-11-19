using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Data.Repositories
{
    public class RoleRepository : RoleStore<Role>, IGenericRepository<Role>
    {
        private readonly DbSet<ProjectParticipationHistory> _dbSetParticipationHistories;
        private readonly PMContext _context;
        private readonly DbSet<Role> _dbSet;

        public RoleRepository(PMContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Role>();
            _dbSetParticipationHistories = context.Set<ProjectParticipationHistory>();
        }

        public void Create(Role item)
        {
            throw new NotImplementedException();
        }

        public Role Find(string predicate)
        {
            throw new NotImplementedException();
        }

        public Role FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> Get(Func<Role, bool> predicate)
        {
            throw new NotImplementedException();
        }
       
        public void Remove(Role item)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> SelectQuery(string query, object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Update(Role item)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Role>> IGenericRepository<Role>.Get()
        {
            throw new NotImplementedException();
        }
    }
}
