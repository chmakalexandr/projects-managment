using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectRoleRepository
    {
        IEnumerable<ProjectRole> GetProjectRoleList();
        ProjectRole GetProjectRole(int id);
        void Create(ProjectRole item);
        void Update(ProjectRole item);
        void Delete(int id);
        void Save();
    }
}
