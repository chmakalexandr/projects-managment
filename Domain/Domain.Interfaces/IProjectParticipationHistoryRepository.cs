using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProjectParticipationHistoryRepository
    {
        IEnumerable<ProjectParticipationHistory> GetProjectParticipationHistoryList();
        ProjectParticipationHistory GetProjectParticipationHistory(int id);
        void Create(ProjectParticipationHistory item);
        void Update(ProjectParticipationHistory item);
        void Delete(int id);
        void Save();
    }
}
