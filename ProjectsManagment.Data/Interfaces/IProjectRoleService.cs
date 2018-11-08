using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsManagment.Entity;
using ProjectsManagment.Entity.Models;

namespace ProjectsManagment.Data.Interfaces
{
    public interface IProjectRoleService
    {
        IQueryable<ProjectRole> SelectQuery(string query, params object[] parameters);

        void Insert(ProjectRole projectRole);

        void Update(ProjectRole projectRole);

        void Delete(ProjectRole projectRole);

        ProjectRole FindById(int id);

        ProjectRole Find(string predicate);
    }
}
