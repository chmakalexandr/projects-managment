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
    public class ProjectService : IProjectService
    {
        private UnitOfWork unitOfWork;
        protected ProjectService()
        {
            unitOfWork = new UnitOfWork();

        }
        
        public virtual IQueryable<Project> SelectQuery(string query, params object[] parameters) { return unitOfWork.Projects.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(Project project)
        {
            unitOfWork.Projects.Insert(project);
            unitOfWork.Save();
        }

        public virtual void Update(Project project)
        {
            unitOfWork.Projects.Update(project);
            unitOfWork.Save();
        }

        public virtual void Delete(Project project)
        {
            unitOfWork.Projects.Remove(project);
            unitOfWork.Save();
        }

        public virtual void DeleteById(int id)
        {
            unitOfWork.Projects.RemoveById(id);
            unitOfWork.Save();
        }

        public Project FindById(int id)
        {
            return unitOfWork.Projects.FindById(id);
        }

        public virtual Project Find(string predicate)
        {
            return unitOfWork.Projects.Find(predicate);
        }
    }
}
