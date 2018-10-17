using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Project> Projects { get; }
        IGenericRepository<Role> Roles { get; }
        IGenericRepository<ProjectRole> ProjectRoles { get; }
        IGenericRepository<ProjectParticipationHistory> ProjectParticipationHistories { get; }
    }
}
