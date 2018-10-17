using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectParticipationHistoryRepository
    {
        IEnumerable<ProjectParticipationHistory> GetParticipationTypeList();
        ProjectParticipationHistory GetParticipationType(int id);
        void Create(ProjectParticipationHistory item);
        void Update(ProjectParticipationHistory item);
        void Delete(int id);
        void Save();
    }
}
