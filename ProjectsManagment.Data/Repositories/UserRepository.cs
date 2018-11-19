using Infrastructure.Data;
using ProjectsManagment.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectsManagment.Entity.Models;

namespace ProjectsManagment.Data.Repositories
{
    public class UserRepository : UserStore<User>, IGenericRepository<User>
    {
        private readonly DbSet<ProjectParticipationHistory> _dbSetParticipationHistories;
        private readonly PMContext _context;
        private readonly DbSet<User> _dbSet;
        public UserRepository(PMContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
            _dbSetParticipationHistories = context.Set<ProjectParticipationHistory>();
        }

              

        public void AddToProject(ProjectParticipationHistory participationHistory)
        {
            _dbSetParticipationHistories.Add(participationHistory);
        }

        public void RemoveFromProject(ProjectParticipationHistory participationHistory)
        {
            _dbSetParticipationHistories.Remove(participationHistory);
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public IEnumerable<User> Get(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User Find(string predicate)
        {
            throw new NotImplementedException();
        }

        public void Insert(User item)
        {
            _dbSet.Add(item);
        }

        public void Remove(User item)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> SelectQuery(string query, object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
