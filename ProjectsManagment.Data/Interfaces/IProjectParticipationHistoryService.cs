using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectParticipationHistoryService
    {
        IQueryable<ProjectParticipationHistory> SelectQuery(string query, params object[] parameters);

        void Insert(ProjectParticipationHistory projectParticipationHistory);

        void Update(ProjectParticipationHistory projectParticipationHistory);

        void Delete(ProjectParticipationHistory projectParticipationHistory);

        ProjectParticipationHistory FindById(int id);

        ProjectParticipationHistory Find(string predicate);
    }
}
