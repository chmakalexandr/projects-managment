using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using ProjectsManagment.Data.Interfaces;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data
{
    public class UserService : IUserService
    {
        private UnitOfWork unitOfWork;

        #region Constructor
        public UserService()
        {
            unitOfWork = new UnitOfWork();

        }
        #endregion Constructor

        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<User> SelectQuery(string query, params object[] parameters) { return unitOfWork.Users.SelectQuery(query, parameters).AsQueryable(); }
        
        public virtual void Insert(User user)
        {
            unitOfWork.Users.Insert(user);
            unitOfWork.Save();
        }

        public virtual void Update(User user)
        {
            unitOfWork.Users.Update(user);
            unitOfWork.Save();
        }

        public virtual void Delete(User entity)
        {
            unitOfWork.Users.Remove(entity);
            unitOfWork.Save();
        }

        public virtual void DeleteById(int id)
        {
            unitOfWork.Users.RemoveById(id);
            unitOfWork.Save();
        }

        
        public void AddToProject(ProjectParticipationHistory participationHistory)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromProject(ProjectParticipationHistory participationHistory)
        {
            throw new NotImplementedException();
        }
                
        public User FindById(int id)
        {
            return unitOfWork.Users.FindById(id);
        }

        public virtual User Find(string predicate)
        {
            return unitOfWork.Users.Find(predicate);
        }
    }
}
