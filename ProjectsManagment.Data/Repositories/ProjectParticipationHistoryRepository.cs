using Infrastructure.Data;
using ProjectsManagment.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsManagment.Data.Repositories
{
    public class ProjectParticipationHistoryRepository : EFGenericRepository<ProjectParticipationHistory>
    {
        public ProjectParticipationHistoryRepository(PMContext context) : base(context)
        {

        }
    }
   
}
