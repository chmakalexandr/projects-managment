using ProjectsManagment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using ProjectsManagment.Data.Interfaces;


namespace ProjectsManagment.Data.Services
{
    public class RoleService : IRoleService
    {
        private UnitOfWork unitOfWork;
        protected RoleService()
        {
            unitOfWork = new UnitOfWork();

        }
        

        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<Role> SelectQuery(string query, params object[] parameters) { return unitOfWork.Roles.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(Role role)
        {
            unitOfWork.Roles.Insert(role);
            unitOfWork.Save();
        }

        public virtual void Update(Role role)
        {
            unitOfWork.Roles.Update(role);
            unitOfWork.Save();
        }

        public virtual void Delete(Role role)
        {
            unitOfWork.Roles.Remove(role);
            unitOfWork.Save();
        }


        public Role FindById(int id)
        {
            return unitOfWork.Roles.FindById(id);
        }

        public virtual Role Find(string predicate)
        {
            return unitOfWork.Roles.Find(predicate);
        }
    }
}
