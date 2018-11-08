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
    public class ProjectParticipationHistoryService : IProjectParticipationHistoryService
    {
        private UnitOfWork unitOfWork;
        protected ProjectParticipationHistoryService()
        {
            unitOfWork = new UnitOfWork();

        }
        
        //public virtual TEntity Find(params object[] keyValues) { return unitOfWork._repository.Find(keyValues); }

        public virtual IQueryable<ProjectParticipationHistory> SelectQuery(string query, params object[] parameters) { return unitOfWork.ProjectParticipationHistories.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(ProjectParticipationHistory projectRole)
        {
            unitOfWork.ProjectParticipationHistories.Insert(projectRole);
            unitOfWork.Save();
        }

        public virtual void Update(ProjectParticipationHistory projectRole)
        {
            unitOfWork.ProjectParticipationHistories.Update(projectRole);
            unitOfWork.Save();
        }

        public virtual void Delete(ProjectParticipationHistory projectRole)
        {
            unitOfWork.ProjectParticipationHistories.Remove(projectRole);
            unitOfWork.Save();
        }

        public virtual void DeleteById(int id)
        {
            unitOfWork.ProjectParticipationHistories.RemoveById(id);
            unitOfWork.Save();
        }

        public ProjectParticipationHistory FindById(int id)
        {
            return unitOfWork.ProjectParticipationHistories.FindById(id);
        }

        public virtual ProjectParticipationHistory Find(string predicate)
        {
            return unitOfWork.ProjectParticipationHistories.Find(predicate);
        }
    }
}
