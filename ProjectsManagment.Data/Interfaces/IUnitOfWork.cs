using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Data.Repositories;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IUnitOfWork
    {
        UserRepository Users { get; }
        ProjectRepository Projects { get; }
        RoleRepository Roles { get; }
        ProjectParticipationHistoryRepository ProjectParticipationHistories { get; }
        void Save();
    }
}
