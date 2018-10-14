using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Core;

namespace Infrastructure.Data
{
    class UserService : IService<User>
    {
        private UnitOfWork unitOfWork;
        public UserService() 
        {
            unitOfWork = new UnitOfWork();
        }

        public virtual User Find(string predicate) { return unitOfWork.UserRepository.Find(predicate); }

        public virtual IQueryable<User> SelectQuery(string query, params object[] parameters) { return unitOfWork.UserRepository.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(User entity) { unitOfWork.UserRepository.Create(entity); }
        
        public virtual void Update(User entity) { unitOfWork.UserRepository.Update(entity); }

        public virtual void Delete(int id) { unitOfWork.UserRepository.Delete(id); }

        public virtual void Delete(User entity) { unitOfWork.UserRepository.Remove(entity); }
    }
}
