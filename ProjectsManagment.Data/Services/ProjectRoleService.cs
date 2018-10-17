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
    public class ProjectRoleService : IProjectRoleService
    {
        private UnitOfWork unitOfWork;
        protected ProjectRoleService()
        {
            unitOfWork = new UnitOfWork();

        }


        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<ProjectRole> SelectQuery(string query, params object[] parameters) { return unitOfWork.ProjectRoles.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(ProjectRole projectRole)
        {
            unitOfWork.ProjectRoles.Insert(projectRole);
            unitOfWork.Save();
        }

        public virtual void Update(ProjectRole projectRole)
        {
            unitOfWork.ProjectRoles.Update(projectRole);
            unitOfWork.Save();
        }

        public virtual void Delete(ProjectRole projectRole)
        {
            unitOfWork.ProjectRoles.Remove(projectRole);
            unitOfWork.Save();
        }


        public ProjectRole FindById(int id)
        {
            return unitOfWork.ProjectRoles.FindById(id);
        }

        public virtual ProjectRole Find(string predicate)
        {
            return unitOfWork.ProjectRoles.Find(predicate);
        }
    }
}
